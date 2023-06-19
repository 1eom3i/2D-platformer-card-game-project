using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRotation : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        // Rotate the StickPivot GameObject around the Z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}