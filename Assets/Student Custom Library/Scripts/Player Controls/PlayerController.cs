using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public void OnInputAction(InputAction.CallbackContext ctx) => SetMoveDirection(ctx.ReadValue<Vector2>());

    // Update is called once per frame
    private void OnEnable()
    {
        GameObject player = this.gameObject;
        player.name = "Player";

        Renderer renderer = player.GetComponentInChildren< Renderer > ();
        renderer.material.color = player.GetComponent<ColorPicker>().GetColor();
    }

    private void OnDisable()
    {
        
    }

    private void FixedUpdate()
    {
        Move();

        if ( transform.position.y < -10)
        {
            transform.position = Vector3.up * 25;
            Destroy(gameObject);
            IslandManager.Instance.SwitchLevels("Island1");
           
        }
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

        hasPowerUp = GameManager.Instance.debugPowerUpRepel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
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
        if (other.CompareTag("PowerUp"))
            Destroy(other.gameObject);
        {
            Debug.Log("Power up collected");
            gameObject.layer = LayerMask.NameToLayer("PowerUp");
        }
        if (other.CompareTag("PowerUp"))
        {
            PowerUpController powerUpController = other.GetComponent<PowerUpController>();
            if (powerUpController != null)
            {
                other.gameObject.SetActive(false);
                StartCoroutine(PowerUpCooldown(powerUpController.cooldown));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            if (transform.position.y < 0)
            {
                transform.position = Vector3.up * 25;
                PortalController portal = other.GetComponent<PortalController>();
                string destination = portal.GetDestination();
                if (portal != null)
                {
                    IslandManager.Instance.SwitchLevels(destination);
                }
            }
        }
    }

    private IEnumerator PowerUpCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }
}