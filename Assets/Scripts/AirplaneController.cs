using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    private float currentSpeed = 0f;
    private float currentRotationSpeed = 0f;

    private CinemachineVirtualCamera vcam;

    [Header("Speed")]
    [Range(10f, 100f)]
    [SerializeField] private float defaultMoveSpeed = 40f;
    [SerializeField] private float maxSpeed = 60f;
    // Start is called before the first frame update
    [Range(10f, 100f)]
    [SerializeField] private float defaultRotateSpeed = 100f;
    [Range(10f, 100f)]
    [SerializeField] private float accelerateMultiplier = 1f;
    
    [Header("Camera")]
    [SerializeField] private float defaultFov = 10f;
    [SerializeField] private float maxFov = 100f;
    [SerializeField] private float fovAccelerateMultiplier = 1f;

    void Start()
    {
        vcam = transform.GetChild(0).GetChild(0).GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * currentSpeed* Time.deltaTime);
        InputManager();
        Rotate();
        Accelerate();
    }

    void InputManager(){

    }

    void Rotate(){
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0,0,1),defaultRotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0,0,-1),defaultRotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W)){
            transform.Rotate(new Vector3(1,0,0),defaultRotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Rotate(new Vector3(-1,0,0),defaultRotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(new Vector3(0,-1,0),defaultRotateSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(new Vector3(0,1,0),defaultRotateSpeed * Time.deltaTime); 
        }

    }

    void Accelerate(){
        if(Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, accelerateMultiplier * Time.deltaTime);

            //改变Fov

            vcam.m_Lens.FieldOfView = Mathf.Lerp(vcam.m_Lens.FieldOfView, maxFov, fovAccelerateMultiplier * Time.deltaTime);

        }
        else{
            currentSpeed = defaultMoveSpeed;
            
            //恢复Fov

            vcam.m_Lens.FieldOfView = defaultFov;
            
        }
    }


}
