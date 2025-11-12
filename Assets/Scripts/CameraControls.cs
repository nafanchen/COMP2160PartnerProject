using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public Transform target;
    private float rotateSpeed = 40f;
    private float verticalSpeed = 40f;  
    private Vector3 offset = new Vector3(0, 4, -10);

    private PlayerInput cameraAction; 
    private Vector2 lookInput; 
    private Vector2 dpadInput;
    private float yaw = 0f;    
    private float pitch = 0f;               
    private bool isRightMousePressed = false; 

    private float zoomSpeed = 2f;
    private float dpadZoomSpeed = 5f;
    private float minZoom = -5f;
    private float maxZoom = -13f;

    private void Awake()
    {
        cameraAction = new PlayerInput();

        cameraAction.GameWorld.Camera.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        cameraAction.GameWorld.Camera.canceled += ctx => lookInput = Vector2.zero;

        cameraAction.GameWorld.RightClick.performed += ctx => isRightMousePressed = true;
        cameraAction.GameWorld.RightClick.canceled += ctx => isRightMousePressed = false;

        cameraAction.GameWorld.Scroll.performed += ctx => ZoomAdjust(ctx.ReadValue<Vector2>().y);

        cameraAction.GameWorld.Dpad.performed += ctx => dpadInput = ctx.ReadValue<Vector2>();
        cameraAction.GameWorld.Dpad.canceled += ctx => dpadInput = Vector2.zero;
    }

    private void ZoomAdjust(float scrollInput)
    {   
        offset.z += scrollInput * zoomSpeed * Time.deltaTime;

        offset.z = Mathf.Clamp(offset.z, maxZoom, minZoom);
    }


    private void OnEnable()
    {
        cameraAction.GameWorld.Enable();
    }

    private void OnDisable()
    {
        cameraAction.GameWorld.Disable();
    }

    private void Update()
    {
        yaw += lookInput.x * rotateSpeed * Time.deltaTime;

        if (isRightMousePressed)
        {
            pitch -= lookInput.y * verticalSpeed * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, -30f, 60f);
        }

        if (dpadInput.y != 0)
        {
            ZoomAdjust(dpadInput.y * dpadZoomSpeed);
        }

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        
        Vector3 rotatedOffset = rotation * offset;

        transform.position = target.position + rotatedOffset;

        target.rotation = Quaternion.Euler(0, yaw, 0);

        transform.LookAt(target);
    }
}
