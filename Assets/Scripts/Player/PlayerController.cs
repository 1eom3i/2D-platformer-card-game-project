using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField]
    private float speed = 1.0f;

    public int health = 1000;
    public int boss_index;
    private Rigidbody2D rb;
    private float input;
    private BoxCollider2D boxCollider;

    public float moveWaitTime = 0.2f;
    public float moveTimeLeft = 0;
    public bool isMovingRight = false;
    public bool isMovingLeft = false;
    public bool isMoveSpike;
    public float acc;

    private int move_counter;
    private int back_counter;
    private int jump_counter;
    private int dash_counter;
    //private int slash_counter;
    
    // Bool to reset spike in scene 2
    public bool resetSpike = false;
    
    //fall and restart
    public Vector3 respawnPoint; //recall where palyer restart
    public Vector3 checkPoint;
    public GameObject fallDetector; //link the script to FallDetector
    public int defaultLayer;
	public bool isGrounded=false;
	private Animator cloudanim;
	public GameObject Cloud;
	private Animator anim;

    //check if player is undeground
    public bool isUnderground=false;

    //public GameObject rockpieces;
    private void Awake()
    {
        if (PlayerController.instance == null) { PlayerController.instance = this; }
        else { Destroy(this); }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
		Cloud = GameObject.Find("Cloud");
        respawnPoint = transform.position;
        move_counter = 0;
        jump_counter = 0;
        back_counter = 0;
        dash_counter = 0;
        defaultLayer = gameObject.layer;
        //slash_counter = 0;
    }

    private void Update()
    {
        
        rb.velocity = new Vector2(acc * speed, rb.velocity.y);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);       
        
    }

    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GameObject colliObject = collision.gameObject;
    //     // Check if the collision is with an object tagged as "Player"
    //     if (colliObject.CompareTag("Rock"))
    //     {
    //         if (acc > 20)
    //         {
    //             colliObject.SetActive(false);
    //             rockpieces.SetActive(true);
    //         }
    //
    //         // Print a message to the console
    //         Debug.Log("The player collided with this object!");
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector" )
        {
            float current_x = transform.position.x;
            float current_y = transform.position.y;
            transform.position = checkPoint;
            rb.velocity = new Vector2(0, 0);
            Analyzer.instance.sendDeathData(current_x, current_y, "FallDetector");
        }
        else if (collision.tag == "Spike")
        {
            float spike_current_x = transform.position.x;
            float spike_current_y = transform.position.y;
            Analyzer.instance.sendDeathData(spike_current_x, spike_current_y, "Spike");
            transform.position = checkPoint;
            rb.velocity = new Vector2(0, 0);
            moveTimeLeft = 0;
            Debug.Log("Spike");
        }
        else if (collision.tag == "Checkpoint")
        {
            checkPoint = collision.transform.position;
            rb.velocity = new Vector2(0, 0);
        }
        else if (collision.tag == "Underground")
        {
            isUnderground = true;
        }
        // else if (collision.tag == "Rock")
        // {
        //     GameObject colliObject = collision.gameObject;
        //     if (acc > 20)
        //     {
        //         colliObject.SetActive(false);
        //     }
        // }

    }
	public LayerMask groundLayer;
	public float groundCheckRadius = 0.1f;
	public Transform groundCheckTransform;

	void FixedUpdate()
	{
		float hor = Input.GetAxis ("Horizontal");
		isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
		anim.SetFloat ("Speed", rb.velocity.x);
		//rb2d.velocity = new Vector2 (hor * maxSpeed, rb.velocity.y);
		anim.SetBool ("IsGrounded", isGrounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            float spike_current_x = transform.position.x;
            float spike_current_y = transform.position.y;
            Analyzer.instance.sendDeathData(spike_current_x, spike_current_y, "Monster");
            //transform.position = checkPoint;
            health -= 100;
			if (health <= 0)
        	{
            	transform.position = checkPoint;
            	rb.velocity = new Vector2(0, 0);
            	moveTimeLeft = 0;
        	}
			else{

            	rb.velocity = new Vector2(0, 0);
			}

            Debug.Log("Monster");
        }

        else if (collision.gameObject.tag == "Rock")
        {
            GameObject colliObject = collision.gameObject;
            if (acc > 20)
            {
                colliObject.SetActive(false);
            }
            Debug.Log("Rock collision");
        }
        
        else if (collision.gameObject.tag == "key")
        {
            GameObject doorObject = GameObject.FindWithTag("door");
            GameObject keyObject = GameObject.FindWithTag("key");
            Destroy(doorObject);
            Destroy(keyObject);
            Debug.Log("Key get");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            GameObject colliObject = collision.gameObject;
            if (acc > 20)
            {
                colliObject.SetActive(false);
            }

            Debug.Log("Rock collision");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Underground")
        {
            isUnderground = false;
        }
    }

    public GameObject boss;

    public void FreezeBoss()
    {
        // Get the BossController script attached to the boss GameObject
        BossController bossController = boss.GetComponent<BossController>();

        // Now you can call methods from the BossController script
        bossController.Freeze();
    }
    
    public float invulnerableDuration = 5f;

    public void FreeDamage()
    {
        StartCoroutine(InvulnerabilityCoroutine());
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        // Set the player to the InvulnerablePlayer layer
        gameObject.layer = LayerMask.NameToLayer("InvulnerablePlayer");

        // Wait for the invulnerable duration
        yield return new WaitForSeconds(invulnerableDuration);

        // Set the player back to the default layer
        gameObject.layer = defaultLayer;
    }
    
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 10 * speed);
    }

    public void SuperJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 25 * speed);
    }
    
    public void MoveRight()
    {
        if(isMovingRight) { moveTimeLeft += moveWaitTime; }
        else if (isMovingLeft) { moveTimeLeft = moveWaitTime; }
        else { StartCoroutine(Move(15)); }
    }
    public void MoveBack()
    {
        if (isMovingLeft) { moveTimeLeft += moveWaitTime; }
        else if (isMovingRight) { moveTimeLeft = moveWaitTime; }
        else { StartCoroutine(Move(-15)); }
    }

    public void Dash()
    {
        if(isMovingRight) { moveTimeLeft += moveWaitTime; }
        else if (isMovingLeft) { moveTimeLeft = moveWaitTime; }
        else { StartCoroutine(Move(30)); }
    }

    public void DashBack()
    {
        if (isMovingLeft) { moveTimeLeft += moveWaitTime; }
        else if (isMovingRight) { moveTimeLeft = moveWaitTime; }
        else { StartCoroutine(Move(-30)); }
    }
    
    //private bool isSuperDashing = false;
    public float superDashSpeed = 30f;
    public float superDashDuration = 2f;
    
    public void SuperDash()
    {
        StartCoroutine(SetSuperDashCollisionCoroutine(true));
        StartCoroutine(SuperDashCoroutine());
    }
    
    private IEnumerator SuperDashCoroutine()
    {
        //SetSuperDashCollision(true);
        //isSuperDashing = true;
        moveWaitTime = 1.5f;
        if (isMovingLeft) { moveTimeLeft += moveWaitTime; }
        else if (isMovingRight) { moveTimeLeft = moveWaitTime; }
        else
        {
            StartCoroutine(Move(25));
        }
        
        yield return new WaitForSeconds(1.5f);
        
        
        //isSuperDashing = false;
        moveWaitTime = 0.2f;
        // Re-enable collisions after the SuperDash
        StartCoroutine(SetSuperDashCollisionCoroutine(false));
    }
    private IEnumerator SetSuperDashCollisionCoroutine(bool ignore)
    {
        // Wait for the next fixed update to ensure that the physics calculations are done after setting the collision state
        yield return new WaitForFixedUpdate();
    
        SetSuperDashCollision(ignore);
    }
    
    private void SetSuperDashCollision(bool enable)
    {
        int playerLayer = LayerMask.NameToLayer("Player");
        int spikesLayer = LayerMask.NameToLayer("Spikes");
        int enemiesLayer = LayerMask.NameToLayer("Enemies");
    
        // When enabling the superdash, ignore collisions with spikes and enemies.
        // When disabling the superdash, stop ignoring collisions with spikes and enemies.
        Physics2D.IgnoreLayerCollision(playerLayer, spikesLayer, enable);
        Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, enable);
    }
    public bool facingRight=true;
    private IEnumerator Move(float speed)
    {
		if((speed<0 && facingRight) || (speed>0 && !facingRight)) {Flip();}
        isMovingRight = true;
        moveTimeLeft = moveWaitTime;
        acc = speed;
        while (moveTimeLeft > 0)
        {
            
            //acc = Mathf.Lerp(0, 10, (waitTime - timeLeft) / waitTime);
            //PlayerController.instance.acc = acc;
            moveTimeLeft -= Time.deltaTime;
            yield return null;
        }
     
        //KnightController.instance.spineAnimationState.ClearTrack(0); 
        acc = 0;
        isMovingRight = false;
    }
    public void Flip()
	{
		facingRight=!facingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}
    public float shockDuration = 1f;
    public float shockRange = 10f;
    public int shockDamage = 5;
    private Collider2D[] hitEnemies;
    public GameObject lightningObject;
    
    //Slash card operation
    public void Slash()
    {
        //StartCoroutine(SlashCoroutine());
        StartCoroutine(ElectricShockCoroutine());
    }

    private IEnumerator ElectricShockCoroutine()
    {
        float startTime = Time.time;

        // Use a BoxCollider2D for the wider attack range
        BoxCollider2D shockCollider = gameObject.AddComponent<BoxCollider2D>();
        shockCollider.isTrigger = true;
        shockCollider.size = new Vector2(shockRange, shockRange);
        
        // Disable collisions with the "Items" layer
        int playerLayer = gameObject.layer;
        int itemsLayer = LayerMask.NameToLayer("Spikes");
        Physics2D.IgnoreLayerCollision(playerLayer, itemsLayer, true);
        
        while (Time.time < startTime + shockDuration )
        {
            hitEnemies = Physics2D.OverlapBoxAll(transform.position, new Vector2(shockRange, shockRange), 0);

            foreach (Collider2D enemyCollider in hitEnemies)
            {
                // Apply damage and instantiate lightning effect
                if (enemyCollider.CompareTag("Monster"))
                {
                    GameObject enemyGameObject = enemyCollider.gameObject;
                    MonsterController enemyScript = enemyGameObject.GetComponent<MonsterController>();
                    enemyScript.TakeDamage(1);
                    // if (enemyScript.health <= 0)
                    // {
                    //     // Handle boss death
                    //     enemyGameObject.SetActive(false);
                    // }

                    UpdateLightningPositionAndScale(enemyGameObject);

                    // Set the lightning trigger to play the animation
                    Animator lightningAnimator = lightningObject.GetComponent<Animator>();
                    lightningAnimator.SetTrigger("Playlightening");

                    lightningObject.SetActive(true);
                }
                else if (enemyCollider.CompareTag("Root"))
                {
                    GameObject enemyGameObject = enemyCollider.gameObject;
                    RootController enemyScript = enemyGameObject.GetComponent<RootController>();
                    enemyScript.health -= shockDamage;
                    
                    UpdateLightningPositionAndScale(enemyGameObject);

                    // Set the lightning trigger to play the animation
                    Animator lightningAnimator = lightningObject.GetComponent<Animator>();
                    lightningAnimator.SetTrigger("Playlightening");

                    lightningObject.SetActive(true);
                }
                
                else if (enemyCollider.CompareTag("Rock"))
                {
                    GameObject enemyGameObject = enemyCollider.gameObject;

                    UpdateLightningPositionAndScale(enemyGameObject);

                    // Set the lightning trigger to play the animation
                    Animator lightningAnimator = lightningObject.GetComponent<Animator>();
                    lightningAnimator.SetTrigger("Playlightening");

                    lightningObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    enemyGameObject.SetActive(false);
                }
                
                // else if (enemyCollider.CompareTag("Monster"))
                // {
                //     GameObject enemyGameObject = enemyCollider.gameObject;
                //     MonsterController enemyScript = enemyGameObject.GetComponent<MonsterController>();
                //     enemyScript.health -= shockDamage;
                //     if (enemyScript.health <= 0)
                //     {
                //         enemyGameObject.SetActive(false);
                //         // Handle boss death
                //     }
                //     
                //     UpdateLightningPositionAndScale(enemyGameObject);
                //
                //     // Set the lightning trigger to play the animation
                //     Animator lightningAnimator = lightningObject.GetComponent<Animator>();
                //     lightningAnimator.SetTrigger("Playlightening");
                //
                //     lightningObject.SetActive(true);
                //     Debug.Log("The player monster!");
                //     
                // }
            }

            yield return null;
        }
        
        // Re-enable collisions with the "Items" layer
        Physics2D.IgnoreLayerCollision(playerLayer, itemsLayer, false);

        lightningObject.SetActive(false);

        // Remove the shock collider and lightning effect after the electric shock is complete
        Destroy(shockCollider);
    }

    private void UpdateLightningPositionAndScale(GameObject enemyGameObject)
    {
        // Store the original player position
        //Vector3 originalPlayerPosition = transform.position;
        
        // Update the position and rotation of the lightning
        Vector3 direction = enemyGameObject.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Calculate the distance between the player and the enemy
        float distance = Vector3.Distance(transform.position, enemyGameObject.transform.position);

        // Set the lightning's scale based on the distance
        lightningObject.transform.localScale = new Vector3(distance, lightningObject.transform.localScale.y, lightningObject.transform.localScale.z);

        // Set the lightning's position to be in the middle of the player and the enemy
        lightningObject.transform.position = (transform.position + enemyGameObject.transform.position) / 2;

        lightningObject.transform.rotation = rotation;
        
        // Reset the player's position to the original position
        //transform.position = originalPlayerPosition;
    }

    public void sendCardStatToAnalyzer(bool result)
    {
        Analyzer.instance.sendCardData(result, move_counter, back_counter, jump_counter, dash_counter);
    }

}
