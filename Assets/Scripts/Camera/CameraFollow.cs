using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 lastPos;
    private Vector3 CamPos;
    public float CamSpeed = 0.01f;
    public float BackSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        CamPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(lastPos.x - player.transform.position.x) > 0.0f || Math.Abs(lastPos.y - player.transform.position.y) > 0.0f){
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            lastPos = transform.position;
            CamPos = transform.position;
        }
        else{
            // Debug.Log("????");
            if (Input.GetKey(KeyCode.W)){
                CamPos.y += CamSpeed;
                // Debug.Log(CamPos.y);
                transform.position = CamPos;
                // Debug.Log(transform.position);
            }
            if (Input.GetKey(KeyCode.S))
            {
                CamPos.y -= CamSpeed;
                transform.position = CamPos;
            }
            if (Input.GetKey(KeyCode.A))
            {
                CamPos.x -= CamSpeed;
                transform.position = CamPos;
            }
            if (Input.GetKey(KeyCode.D))
            {
                CamPos.x += CamSpeed;
                transform.position = CamPos;
            }       
        }
        
        if(!Input.anyKey){
            if(transform.position != lastPos){
            // Debug.Log("Reposition");
            float startX = CamPos.x;
            float endX = lastPos.x;
            float startY = CamPos.y;
            float endY = lastPos.y;
            float lerpX = Mathf.Lerp(startX, endX, BackSpeed);
            float lerpY = Mathf.Lerp(startY, endY, BackSpeed);
            transform.position = new Vector3(lerpX,lerpY,-10);
            // Debug.Log(lerpX);
            // Debug.Log(lerpY);
            }
            CamPos = transform.position;
        }
    }
}
