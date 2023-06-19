using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5.0f; // the speed at which the object moves
    private int direction = 1; // the direction the object is currently moving (-1 = left, 1 = right)
    public bool isCollide = false;
    public bool horizontal = false;

    void Update()
    {
        if (horizontal)
        {
            transform.Translate(new Vector3(0, direction * speed * Time.deltaTime, 0));
            if (isCollide)
            {
                PlayerController.instance.transform.Translate(new Vector3(0, direction * speed * Time.deltaTime, 0));
            }
        }
        else
        {
            // move the object left or right based on the current direction and speed
            transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0));
            if (isCollide)
            {
                PlayerController.instance.transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0));
            }
        }
        if (((transform.position.x < -9.5 || transform.position.x > 26.5) && transform.position.y < -10))//|| (transform.position.x > 20 && (transform.position.y < -2 || transform.position.y > 13.5)))
        {
            direction *= -1;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("pCollider");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {  
            isCollide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            isCollide = false;
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pCollider"))
        {
            direction *= -1;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("pCollider");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollide = true;
        }
    }
    */
}
