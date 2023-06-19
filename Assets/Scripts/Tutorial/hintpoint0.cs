using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint0 : MonoBehaviour
{
    public static hintpoint0 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint0.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
