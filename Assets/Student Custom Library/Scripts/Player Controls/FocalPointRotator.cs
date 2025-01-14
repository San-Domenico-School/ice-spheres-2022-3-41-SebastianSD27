using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************
 * Attached to Monobehavior
 * Rotation for FocalPoint game object
 * 
 * Sebastian Balakier
 * 1/10/2025, Version 1.0
 ******************************************************/

public class FocalPointRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private PlayerInputActions InputAction;
    private float moveDirection;


    // Start is called before the first frame update
    private void Awake()
    {
        InputAction = new PlayerInputActions();
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveDirection != 0)
        {
            transform.Rotate(Vector3.up, moveDirection * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        InputAction.Player.Enable();
        InputAction.Player.Movement.performed += ctx => CameraRotate(ctx.ReadValue<Vector2>());
        InputAction.Player.Movement.canceled += ctx => CameraRotate(Vector2.zero);
    }

    private void OnDisable()
    {
        InputAction.Player.Disable();
    }

    private void CameraRotate(Vector2 value)
    {
        moveDirection = Input.x;
    }

}