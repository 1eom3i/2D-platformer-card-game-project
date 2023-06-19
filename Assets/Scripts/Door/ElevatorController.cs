using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Transform pointA;
    public Transform pointB;
    private bool movingToPointB;

    private void Update()
    {
        MoveElevator();
    }

    private void MoveElevator()
    {
        if (movingToPointB)
        {
            // Move towards point B
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);

            // If the elevator reaches point B, switch direction
            if (Vector3.Distance(transform.position, pointB.position) < 0.01f)
            {
                movingToPointB = false;
            }
        }
        else
        {
            // Move towards point A
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);

            // If the elevator reaches point A, switch direction
            if (Vector3.Distance(transform.position, pointA.position) < 0.01f)
            {
                movingToPointB = true;
            }
        }
    }
}
