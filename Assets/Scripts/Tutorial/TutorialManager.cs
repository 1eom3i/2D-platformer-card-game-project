using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // public GameObject[] popUps;
    // private int popUpIndex = 0;
    public ItemJumpCard itemJumpCard;
    bool collide = false;
    public GameObject go1;
    public GameObject go12;
    public GameObject go13;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;
    public GameObject go5;
    public GameObject go6;
    public GameObject go7;
    public GameObject go8;
    public GameObject go9;
    public GameObject go10;
    public GameObject redrawbutton;
    public GameObject pausebutton;
    public GameObject remainbutton;
    private Tween tween1;
    private Tween tween2;
    private Tween tween3;

    // Start is called before the first frame update
    void Start()
    {
        itemJumpCard.collideEvent += checkCollide;
        go2.SetActive(false);
        go3.SetActive(false);
        go4.SetActive(false);
        go5.SetActive(false);
        go6.SetActive(false);
        go7.SetActive(false);
        go8.SetActive(false);
        go9.SetActive(false);
        go10.SetActive(false);
        tween1 = redrawbutton.GetComponent<Outline>().DOFade(1, .5f).SetLoops(-1, LoopType.Yoyo);
        tween2 = remainbutton.GetComponent<Outline>().DOFade(1, .5f).SetLoops(-1, LoopType.Yoyo); 
    } 

    void Update()
    {
        if(PlayerController.instance.isMovingRight == true){
            tween1.Kill();
            tween2.Kill();
            redrawbutton.GetComponent<Outline>().DOFade(0, .01f);
            remainbutton.GetComponent<Outline>().DOFade(0, .01f);
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);
        }
        if (hintpoint0.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
        }
        if(collide){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(true);
        }
        if(hintpoint.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(true);
        }
        if(hintpoint11.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
        }
        if(hintpoint2.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(true);
        }
        if(hintpoint21.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
        }
        if(hintpoint3.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
            go7.SetActive(true);
        }
        if(hintpoint31.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
            go7.SetActive(false);
        }
        if(hintpoint4.instance.check == true){
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
            go7.SetActive(false);
            go8.SetActive(true);
        }
        if(hintpoint5.instance.check == true){
            tween3 = pausebutton.GetComponent<Outline>().DOFade(1, .5f).SetLoops(-1, LoopType.Yoyo);            
            go1.SetActive(false);
            go12.SetActive(false);
            go13.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
            go7.SetActive(false);
            go8.SetActive(false);
            go9.SetActive(true);
            go10.SetActive(true);
        }
    }
    // Update is called once per frame
    // void Update()
    // {
    //     for (int i = 0; i < popUps.Length; i++)
    //     {
    //         if (i == popUpIndex){
    //             if(check == false){
    //                 popUps[i].SetActive(true);
    //                 Invoke("disappear", 5);
    //                 check = true;
    //             }
                
    //         } else {
    //             popUps[i].SetActive(false);
    //         }
    //     }
    //     if(popUpIndex == 0){
    //         if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)){
    //             check = false;
    //             popUpIndex++;
    //         }  
    //     } else if (popUpIndex == 1){
    //         if (ShowRemain.instance.check == true){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } 
    //     else if (popUpIndex == 2){
    //         if (PlayerController.instance.isMovingRight == true){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } else if (popUpIndex == 3){
    //         if(collide){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } else if (popUpIndex == 4){
    //         if(hintpoint.instance.check == true){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } else if (popUpIndex == 5){
    //         if(hintpoint2.instance.check == true){
    //             check = false;
    //             popUpIndex++;
    //         }  
    //     } else if (popUpIndex == 6){
    //         if(hintpoint3.instance.check == true){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } else if (popUpIndex == 7){
    //         if(hintpoint4.instance.check == true){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } else if (popUpIndex == 8){
    //         if(hintpoint5.instance.check == true){
    //             check = false;
    //             popUpIndex++;
    //         }
    //     } 
    // }

    // void disappear()
    // {
    //     popUps[popUpIndex].SetActive(false);
    // }

    void checkCollide()
    {
        collide = true;
    }
}
