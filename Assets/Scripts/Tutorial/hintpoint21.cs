using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint21 : MonoBehaviour
{
    public static hintpoint21 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint21.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
