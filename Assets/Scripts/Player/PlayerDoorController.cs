using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorController : MonoBehaviour
{
    public GameObject door;

    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "level1-boss-door")
        {
            door.SetActive(true);
            healthBar.SetActive(true);
        }
    }
}
