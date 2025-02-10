using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************
* Repel power up script
* Attached to Monobehavior
*
* Sebastian Balakier
* 2/4/2025, Version 1.0
*******************************************************************/

public class PowerInteractor : MonoBehaviour
{
    //fields
    private float pushForce;
    private Rigidbody iceRB;
    private IceSphereController iceController;

    // Start is called before the first frame update
    private void Start()
    {
        iceRB = GetComponent<Rigidbody>();
        iceController = GetComponent<IceSphereController>();
        pushForce = 1f;
    }

    // Collision with game object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GameObject player = collision.gameObject;
            Rigidbody playerRB = player.GetComponent<Rigidbody>();
            PlayerController playerController = player.GetComponent<PlayerController>();
            Vector3 direction = (player.transform.position - transform.position).normalized;

            if (playerController.hasPowerUp)
            {
                iceRB.AddForce(-direction * playerRB.mass * GameManager.Instance.playerRepelForce * .01f, ForceMode.Impulse);
                Debug.Log("32: Force " + -direction * playerRB.mass *  GameManager.Instance.playerRepelForce);
            }
            else
            {
                playerRB.AddForce(direction * pushForce, ForceMode.Impulse);
            }
        }
    }
}
