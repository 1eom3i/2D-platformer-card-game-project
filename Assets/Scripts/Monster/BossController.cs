using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public GameObject boss;
    public float dashSpeed;
    //public float dashDuration;
    public float dashCooldown;
    public float attackRange;
    public GameObject player;
    private Rigidbody2D rb;
    public int health = 5000;
    private bool isAttacking;

    public float left = -21.35f;
    public float right = 13.45f;
    private bool isCooldown;
    private Vector2 targetPosition;
    public int groundContacts;
    public bool isFrozen = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(StartAttacking());
    }
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
           
            if (!isCooldown && distanceToPlayer <= attackRange)
            {
               
                    StartCoroutine(StartAttacking());
                    StartCoroutine(Cooldown());
            }
                
        }
    }
    
    // private void FixedUpdate()
    // {
    //     // ...
    //     isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    //     if (isGrounded)
    //     {
    //         rb.velocity = new Vector2(0, rb.velocity.y);
    //     }
    // }
    // Your other boss controller code...
   

    public float freezeDuration = 3f;
    public float jumpDuration = 1.5f;
    public float dashDuration = 3f;
    public void Freeze()
    {
        StartCoroutine(FreezeCoroutine());
    }

    private IEnumerator FreezeCoroutine()
    {
        isFrozen = true;

        jumpDuration = 0f;
        dashDuration = 0f;

        yield return new WaitForSeconds(freezeDuration);

        jumpDuration = 1.5f;
        dashDuration = 3f;
        isFrozen = false;
    }
    
    IEnumerator StartAttacking()
    {
        while (true)
        {
            if (!isAttacking)
            {
                // Randomly choose between dash and jump attacks
                int attackType = Random.Range(0, 2);
                if (attackType == 0)
                {
                    StartCoroutine(Dash());
                }
                else
                {
                    StartCoroutine(JumpAttack());
                }
            }
            yield return null;
        }
        
    }

    IEnumerator Dash()
    {
        isAttacking = true;

        float targetX;
        if (transform.position.x < left + (right - left) / 2)
        {
            targetX = right;
        }
        else
        {
            targetX = left;
        }
        float startPositionX = transform.position.x;
        float direction = Mathf.Sign(targetX - startPositionX);
        float dashStartTime = Time.time;

        while (Time.time < dashStartTime + dashDuration)
        {
            float newX = transform.position.x + direction * dashSpeed * Time.deltaTime;
            if (newX > right)
            {
                newX = right;
            }

            if (newX < left)
            {
                newX = left;
            }
            transform.position = new Vector2(newX, transform.position.y);
            yield return null;
        }

        isAttacking = false;
        //StartCoroutine(Cooldown());
    }

    
    IEnumerator JumpAttack()
    {
        isAttacking = true;

        // Set the jump height, duration, and delay between jumps
        float jumpHeight = 5f;
        //float jumpDuration = 1.5f;
        float delayBetweenJumps = 0.15f;

        // Determine the target position
        float targetX;
        if (transform.position.x < left + (right - left) / 2)
        {
            targetX = right;
        }
        else
        {
            targetX = left;
        }

        float horizontalDistance = (targetX - transform.position.x) / 2f; // Divide the distance by 2 for the double jump

        // Save the initial height
        float initialHeight = transform.position.y;

        // Perform two consecutive jumps with horizontal movement
        for (int i = 0; i < 2; i++)
        {
            float jumpStartTime = Time.time;
            Vector2 startPosition = transform.position;
            float endX = startPosition.x + horizontalDistance;

            Vector2 controlPoint = new Vector2((startPosition.x + endX) / 2f, startPosition.y + jumpHeight);
            Vector2 endPosition = new Vector2(endX, startPosition.y);

            while (Time.time < jumpStartTime + jumpDuration)
            {
                float t = (Time.time - jumpStartTime) / jumpDuration;
                float oneMinusT = 1f - t;
                Vector2 position = oneMinusT * oneMinusT * startPosition + 2 * oneMinusT * t * controlPoint + t * t * endPosition;
                transform.position = position;

                yield return null;
            }

            // Wait for a short delay before the next jump
            yield return new WaitForSeconds(delayBetweenJumps);
        }

        // Force the boss to return to the initial height
        transform.position = new Vector2(transform.position.x, initialHeight);

        isAttacking = false;
        //StartCoroutine(Cooldown());
    }
    
    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(dashCooldown);
        isCooldown = false;
    }
    
    private IEnumerator ReEnableCollision(Collider2D playerCollider, Collider2D bossCollider, float duration)
    {
        Physics2D.IgnoreCollision(playerCollider, bossCollider, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreCollision(playerCollider, bossCollider, false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.health -= 10;
            // if (PlayerController.instance.health <= 0)
            // {   
            //     // Load scene with build index 0 (assuming Scene 1 has build index 0)
            //     SceneManager.LoadScene(5);
            //     
            // }
            // Reduce the player's health here
            // PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            // if (playerHealth != null)
            // {
            //     playerHealth.TakeDamage(damageAmount);
            // }

            // Ignore the collision temporarily and re-enable it after 2 seconds
            StartCoroutine(ReEnableCollision(collision.collider, GetComponent<Collider2D>(), 2f));
        }
        // else if (collision.collider.CompareTag("Ground"))
        // {
        //     groundContacts++;
        // }
    }
    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.collider.CompareTag("Ground"))
    //     {
    //         groundContacts--;
    //     }
    // }
}

