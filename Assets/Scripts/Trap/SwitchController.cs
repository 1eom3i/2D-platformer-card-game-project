using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Color newColor = Color.green;

    public static SwitchController instance;
    
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isSwitched();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.color = newColor;
        }
    }

    public bool isSwitched()
    {
        if (spriteRenderer.color == Color.green)
        {
            return true;
        }

        return false;
    }
}

