using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colliObject = collision.gameObject;
        // Check if the collision is with an object tagged as "Player"
        if (colliObject.CompareTag("Player"))
        {
            PlayerController.instance.DashBack();
    
            // Print a message to the console
            Debug.Log("The player collided with this object!");
        }
    }
}
