using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float speed = 1.0f;
    private bool moveRight = true;
    public int health = 50;
    
    private Animator animator;
    public float hurtAnimationDuration = 1.1f; 
    public float deathAnimationDuration = 3f; 
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            // transform.localScale = new Vector2(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            // transform.localScale = new Vector2(-2, 2);
        }
    }
    
    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            health -= damage;
            animator.SetTrigger("Hurt");
            StartCoroutine(ResetHurtAnimation());

            if (health <= 0)
            {
                Die();
            }
        }
    }

    IEnumerator ResetHurtAnimation()
    {
        yield return new WaitForSeconds(hurtAnimationDuration);
        animator.SetTrigger("Reset");
    }
    
    void Die()
    {
        isDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(DisappearAfterDeath());
    }

    IEnumerator DisappearAfterDeath()
    {
        yield return new WaitForSeconds(deathAnimationDuration);

        // You can either disable the object or destroy it
        gameObject.SetActive(false);
        // OR
        // Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonsterTurn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
