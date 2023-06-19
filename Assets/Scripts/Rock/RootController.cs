using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public RockplatformController rockPlatformController;
    public GameObject root;

    public int health = 150;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            rockPlatformController.DetachFromRoot();
            Destroy(root); // Destroy the root
        }
    }
}

