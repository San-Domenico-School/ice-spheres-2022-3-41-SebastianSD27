using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************
 * Attached to PowerIcon
 * Power up controller
 * 
 * Sebastian Balakier
 * 3/6/2025, Version 1.0
 ******************************************************/

public class PowerUpController : MonoBehaviour
{
    [SerializeField] public float cooldown = 7.25f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private Light powerUpIndicator;

    private bool hasPowerUp = false;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    public float GetCooldown()
    {
        return cooldown;
    }
    public IEnumerator PowerUpCooldown()
    {
        Debug.Log("123");
        hasPowerUp = true;
        powerUpIndicator.intensity = 3.5f;
        yield return new WaitForSeconds(cooldown);
        hasPowerUp = false;
        powerUpIndicator.intensity = 0.0f;
    }
        
    
}
