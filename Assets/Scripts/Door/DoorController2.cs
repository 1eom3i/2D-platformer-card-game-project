using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    public GameObject player;
    public GameObject door;

    public bool isClose = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClose)
        {
            if (player.transform.position.x<160)
            {
                door.SetActive(false);
            }
            else
            {
                isClose = true;
                door.SetActive(true);
            }
        }
        
    }
}
