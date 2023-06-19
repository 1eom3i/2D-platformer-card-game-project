using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint3 : MonoBehaviour
{
    public static hintpoint3 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint3.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
