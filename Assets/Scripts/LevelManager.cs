using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;

    public float dis1;

    public float dis2;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        dis1 = Vector2.Distance(PlayerController.instance.transform.position, popUps[0].transform.position);
        dis2 =  Vector2.Distance(PlayerController.instance.transform.position, popUps[1].transform.position); 
        if(dis1<1.5f || dis1>5f)
        { 
            index = 0;
            HidePopupNote();
        }
        else
        {
            popUps[0].SetActive(true);
        }
        
        if (dis2<1.5f || dis2>5f)
        {
           index = 1;
           HidePopupNote();
        }
        else
        {
            popUps[1].SetActive(true);
        }

       
    }
    
    
    void HidePopupNote()
    {
        popUps[index].SetActive(false);
    }


}