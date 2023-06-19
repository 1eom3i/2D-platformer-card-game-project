using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public bool s2 = false;

    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            s2 = !s2;
            cam2.SetActive(s2);
            Debug.Log("s2 " + s2);
        }
    }
}
