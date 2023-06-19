using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement2 : MonoBehaviour
{
    public float moveSpeed = 5.0f; // The speed at which the object moves

    public float startPosx;
    public float startPosy;
    
    void Start()
    {
        startPosx = transform.position.x;
        startPosy = transform.position.y-4;
    }
    void Update() 
    {

        if ((PlayerController.instance.transform.position.x - startPosx) <= 3 &&
            PlayerController.instance.transform.position.y >= startPosy)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime); // Moves the object to the left
        }
        
    }
}
