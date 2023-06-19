using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint11 : MonoBehaviour
{
    public static hintpoint11 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint11.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
