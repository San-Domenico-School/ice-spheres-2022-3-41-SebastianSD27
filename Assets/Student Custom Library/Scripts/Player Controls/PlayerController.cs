using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************
 * Attached to Monobehavior
 * Player controls for movement, collision, etc...
 * 
 * Sebastian Balakier
 * 1/10/2025, Version 1.0
 ******************************************************/

public class PlayerController : MonoBehaviour

{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicator;
    private PlayerInputActions inputAction;
    private Transform focalPoint;
    private float moveForceMagnitude;
    private float moveDirection;
    public bool hasPowerUp;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody>();
        playerCollider = (SphereCollider)GetComponent<Collider>();
        playerCollider.material.bounciness = .04f;
        if (powerUpIndicator != null)
        {
            Light indicatorLight = powerUpIndicator.GetComponent<Light>();
            if (indicatorLight != null)
            {
                indicatorLight.intensity = 0;
            }
        }
    }

    // Update is called once per frame
    private void OnEnable()
    {
        inputAction.Player.Enable();
        inputAction.Enable();
        inputAction.Player.Movement.performed += ctx => SetMoveDirection(ctx.ReadValue<Vector2>());
        inputAction.Player.Movement.canceled += ctx => moveDirection = 0.0f;

        playerRB = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SetMoveDirection(Vector2 value)
    {
        moveDirection = value.y;
    }

    private void AssignLevelValues()
    {
        if (GameManager.Instance != null)
        {
            transform.localScale = GameManager.Instance.playerScale;
            playerRB.mass = GameManager.Instance.playerMass;
            playerRB.drag = GameManager.Instance.playerDrag;
            moveForceMagnitude = GameManager.Instance.playerMoveForce;

            GameObject focalPointObj = GameObject.Find("Focal Point");
            if (focalPointObj != null)
            {
                focalPoint = focalPointObj.transform;
            }
        }
    }

    private void Move()
    {
        if (focalPoint != null)
        {
            Vector3 force = focalPoint.forward.normalized * moveDirection * moveForceMagnitude;
            playerRB.AddForce(force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Startup"))
        {
            collision.gameObject.tag = "Ground";
            if (playerCollider != null && playerCollider.material != null)
            {
                playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            }

            AssignLevelValues();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
    private IEnumerator PowerUpCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }
}