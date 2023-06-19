using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint5 : MonoBehaviour
{
    public static hintpoint5 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint5.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
