using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRemain : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject bg;

    void Start(){
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            bg.SetActive(false);
    }
    public void whenButtonClicked(){
        if(text1.activeInHierarchy == true){
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            bg.SetActive(false);
            
        }
        else
        {
            text1.SetActive(true);
            text2.SetActive(true);
            text3.SetActive(true);
            text4.SetActive(true);
            text5.SetActive(true);
            text6.SetActive(true);
            text7.SetActive(true);
            bg.SetActive(true);
        }
    }
}
