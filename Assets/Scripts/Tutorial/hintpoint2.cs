using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint2 : MonoBehaviour
{
    public static hintpoint2 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint2.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
