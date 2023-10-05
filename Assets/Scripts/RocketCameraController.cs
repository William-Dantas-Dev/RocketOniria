using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCameraController : MonoBehaviour
{
    public GameObject rocketObject;
    public Vector3 cameraOffset;
    public bool rocketNoseCamera;
    public Rect cameraRect;
    public Rect initialRect;
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    
    void Update()
    {
        transform.position = rocketObject.transform.position + cameraOffset;
    }

    public void ChangeCameraRect()
    {
        if(rocketNoseCamera)
        {
            cam.rect = cameraRect;
        }
    }
}
