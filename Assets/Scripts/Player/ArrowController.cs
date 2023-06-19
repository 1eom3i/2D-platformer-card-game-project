using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject player;
    public GameObject finalDestination;
    public float distance = 2f;
    
    void Update()
    {
        // calculate direction and distance from player to final destination
        Vector3 direction = finalDestination.transform.position - player.transform.position;
        float distanceToDestination = Vector3.Distance(player.transform.position, finalDestination.transform.position);
        
        // move arrow in front of player
        //transform.position = player.transform.position +  ;
        
        // rotate arrow to face final destination
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // show or hide arrow based on distance to final destination
        if (distanceToDestination < distance)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}