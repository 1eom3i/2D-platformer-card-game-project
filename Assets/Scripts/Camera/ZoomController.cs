using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private float orizoomsize = 5.0f;
    public float zoomsize = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        orizoomsize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M");
            if (Camera.main.orthographicSize == orizoomsize)
            {
                Camera.main.orthographicSize = zoomsize;
            }
            else
            {
                Camera.main.orthographicSize = orizoomsize;
            }

        }
    }
}