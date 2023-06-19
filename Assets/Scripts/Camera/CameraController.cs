using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 CameraPos;
    [SerializeField] Vector3 offset;
    public float CameraSpeed = 0.01f;

    private void Start()
    {
        player = PlayerController.instance.transform;
        CameraPos = player.position + offset;
        this.transform.position = CameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = new Vector3(CameraSpeed * Input.GetAxis("Horizontal"), CameraSpeed * Input.GetAxis("Vertical"));

        this.transform.position += speed;
    }
}
