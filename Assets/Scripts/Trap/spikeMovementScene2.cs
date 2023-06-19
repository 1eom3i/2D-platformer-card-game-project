using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeMovementScene2 : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Vector3 startPos;
    public GameObject spike;
    bool move = false;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if ((PlayerController.instance.transform.position.y - transform.position.y) >= -2.2 && PlayerController.instance.transform.position.x <= 4 && PlayerController.instance.transform.position.x >= -5)     
        {
            move = true;
        }
        if (move)
        {
            // Move the object leftward based on the move speed
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (PlayerController.instance.resetSpike)
        {
            transform.position = startPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.resetSpike = true;
        }
    }
}
