using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintpoint31 : MonoBehaviour
{
    public static hintpoint31 instance;
    public bool check = false;

    void Awake()
    {
        hintpoint31.instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
}
