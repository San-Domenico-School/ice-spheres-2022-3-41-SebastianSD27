using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************
 * Attached to Monobehavior
 * Game manager script
 * 
 * Sebastian Balakier
 * 1/10/2025, Version 1.0
 ******************************************************/

public class GameManager : MonoBehaviour

{
    // Player fields
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerRepelForce;
    public float playerBounce;

    // Scene fields
    public GameObject[] waypoints;

    // Debug fields
    public bool debugSpawnWaves;
    public bool debugSpawnPortal;
    public bool debugSpawnPowerUp;
    public bool debugPowerUpRepel;

    public bool switchLevels;
    public bool gameOver;
    public bool playerHasPowerUp;

    public static GameManager Instance;

    // Awake is called before any Start methods are called
    void Awake()
    {
        // Awake is called before any Start methods are called
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
        }
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void EnablePlayer()
    {

    }

    private void SwitchLevels()
    {

    }
}
