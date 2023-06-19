using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint4 : MonoBehaviour
{
    public static hintpoint4 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint4.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
