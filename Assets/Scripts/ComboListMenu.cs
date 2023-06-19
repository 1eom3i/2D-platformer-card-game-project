using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComboListMenu : MonoBehaviour
{
    [SerializeField] GameObject superDashContent;
    [SerializeField] GameObject superJumpContent;
    [SerializeField] GameObject freeDamageContent;

    void Update(){
    }
   
    
    public void ViewSuperDash()
    {
        superDashContent.SetActive(true);
        superJumpContent.SetActive(false);
        freeDamageContent.SetActive(false);
    }
    
    public void ViewSuperJump()
    {
        superDashContent.SetActive(false);
        superJumpContent.SetActive(true);
        freeDamageContent.SetActive(false);
    }
    
    public void ViewFreeDamage()
    {
        superDashContent.SetActive(false);
        superJumpContent.SetActive(false);
        freeDamageContent.SetActive(true);
    }
}