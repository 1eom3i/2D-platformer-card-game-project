using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float range = 10.0f;
    private Rigidbody2D rb;
    private bool isMove = false;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Mathf.Abs(PlayerController.instance.transform.position.x - transform.position.x);
        if (distanceToPlayer <= range)
        {
            isMove = true;
        }

        if (isMove && PlayerController.instance.isUnderground)
        {
            // Set the rigidbody to be affected by gravity
            rb.isKinematic = false;
        }
        else
        {
            // Make the spike kinematic and reset its position
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.isMoveSpike = true;
            Debug.Log("Spike");
        }
    }
}