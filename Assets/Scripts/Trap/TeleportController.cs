using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public GameObject port;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.transform.position =
                new Vector2(port.transform.position.x + 3.0f, port.transform.position.y);

            PlayerController.instance.moveTimeLeft = 0;
        }
    }
    
    
}
