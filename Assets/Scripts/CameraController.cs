using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
public float speedH; 
public float speedV;
float yaw; 
float pitch;

    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset =transform.position -player.transform.position;
    }

    // Update is called once per frame
    void Update() {
    yaw += speedH * Input.GetAxis("Mouse X");
    pitch -= speedV * Input.GetAxis("Mouse Y");
    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
}

    void LateUpdate () {

        transform.position = player.transform.position + offset;
        


    }

}
