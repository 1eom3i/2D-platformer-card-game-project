using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockpieceController : MonoBehaviour
{
    public GameObject rock;
    public GameObject rockpiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rock.activeInHierarchy)
        {
            rockpiece.SetActive(true);
        }
     
    }
}
