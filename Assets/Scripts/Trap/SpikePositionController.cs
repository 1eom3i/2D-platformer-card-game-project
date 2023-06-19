using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePositionController : MonoBehaviour
{
    public GameObject[] spikes;
    public Vector3[] originalPosition;

    void Start()
    {
        // Initialize the originalPosition array with the same length as spikes array
        originalPosition = new Vector3[spikes.Length];
        
        for (int i = 0; i<=5; i++)
        {
            originalPosition[i] = spikes[i].transform.position;
        }
       
    }

    void Update()
    {
        if (PlayerController.instance.isMoveSpike)
        {
            for (int i = 0; i<=5; i++)
            {
                 spikes[i].transform.position=originalPosition[i] ;
            }

            PlayerController.instance.isMoveSpike = false;
        }
    }
    // Other methods and functionality here...
}
