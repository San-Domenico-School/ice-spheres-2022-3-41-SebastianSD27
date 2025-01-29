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
        waveNumber = initialWave;
    }

    // Update is called once per frame
    private void Update()
    {
        if (FindObjectsOfType<IceSphereController>().Length == 0 
            && GameObject.FindWithTag("Player") != null)
        {
            SpawnIceWave();
        }

    }

    private void SpawnIceWave()
    {
        Vector3 islandSize = island.GetComponent<MeshCollider>().bounds.size;

        for (int i = 0; i < waveNumber; i++)
        {
            Vector3 spawnPosition = SetRandomPosition(islandSize, 0);
            Instantiate(iceSphere, spawnPosition, iceSphere.transform.rotation);
        }
        if (waveNumber < maximumWave)
        {
            waveNumber++;
        }
    }

    private void SetObjectActive(GameObject obj, float byWaveProbabilty)
    {

    }

    // Spawn ice spheres randomly
    private Vector3 SetRandomPosition(Vector3 islandSize, float PosY)
    {
        float randomX = Random.Range(-islandSize.x / 2, islandSize.x / 2);
        float randomZ = Random.Range(-islandSize.z / 2, islandSize.z / 2);
        return new Vector3(randomX, PosY, randomZ);
    }

    // Countdown timer
    IEnumerator CountdownTimer(string objectTag)
    {
        yield return new WaitForSeconds(1);
    }
}
