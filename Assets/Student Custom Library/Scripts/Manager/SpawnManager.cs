using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************
 * Attached to Monobehavior
 * Objects to spawn throughout game
 * 
 * Sebastian Balakier
 * 1/27/2025, Version 1.0
 ******************************************************/

public class SpawnManager : MonoBehaviour
{
    //Objects to spawn
    [SerializeField] private GameObject iceSphere;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject powerUp;

    //Wave fields
    [SerializeField] private int initialWave;
    [SerializeField] private int increaseEachWave;
    [SerializeField] private int maximumWave;

    //Portal fields
    [SerializeField] private int portalFirstAppearance;
    [SerializeField] private float portalByWaveProbability;
    [SerializeField] private float portalByWaveDuration;

    //Island
    [SerializeField] private GameObject island;

    private Vector3 islandSize;
    private int waveNumber;
    private bool portalActive;
    private bool powerUpActive;

    // Start is called before the first frame update
    private void Start()
    {
        Vector3 islandSize = island.GetComponent<MeshCollider>().bounds.size;
        int waveNumber = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        FindObjectOfType<IceSphereController>().Length == 0
    }

    private void SpawnRatWave()
    {

    }

    private void SetObjectActive(GameObject obj, float byWaveProbabilty)
    {

    }

    // Spawn ice spheres randomly
    private Vector3 SetRandomPosition(float PosY)
    {
        SetRandomPosition: return Vector3.zero;
    }

    // Countdown timer
    IEnumerator CountdownTimer(string objectTag)
    {
        yield return new WaitForSeconds(1);
    }
}
