using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject monster1;
    public GameObject monster2;
    public GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!monster1.activeInHierarchy && !monster2.activeInHierarchy)
        {
            door.SetActive(false);
        }
    }
}
