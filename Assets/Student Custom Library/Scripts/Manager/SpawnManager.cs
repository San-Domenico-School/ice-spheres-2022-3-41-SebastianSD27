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

        if ((waveNumber > portalFirstAppearance || GameManager.Instance.debugSpawnPortal)
            && !portalActive && GameObject.FindGameObjectWithTag("Portal") == null)
                {
                    SetObjectActive(portal, portalByWaveProbability);
                }
    }

    private void SpawnIceWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Vector3 spawnPosition = SetRandomPosition(0);
            Instantiate(iceSphere, spawnPosition, iceSphere.transform.rotation);
        }
        if (waveNumber < maximumWave)
        {
            waveNumber++;
        }
    }

    private void SetObjectActive(GameObject obj, float byWaveProbabilty)
    {
        if (Random.value < waveNumber * byWaveProbabilty * Time.deltaTime ||
            GameManager.Instance.debugSpawnPortal || GameManager.Instance.debugSpawnPowerUp)
        {
            obj.transform.position = SetRandomPosition(obj.transform.position.y);
            StartCoroutine(CountdownTimer(obj.tag));
        }
    }

    // Spawn ice spheres randomly*****************************************************************
    private Vector3 SetRandomPosition(float PosY)
    {
        float randomX = (Random.Range(-islandSize.x, islandSize.x)) / 2.75f;
        float randomZ = Random.Range(-islandSize.z / 2f, islandSize.z / 2f);
        return new Vector3(randomX, PosY, randomZ);
    }

    // Countdown timer
    IEnumerator CountdownTimer(string objectTag)
    {
        float byWaveDuration = 0;

        switch(objectTag)
        {
            case "Portal":
                portal.SetActive(true);
                portalActive = true;
                byWaveDuration = portalByWaveDuration;
                break;
        }

        yield return new WaitForSeconds(waveNumber * byWaveDuration);

        switch(objectTag)
        {
            case "Portal":
                portal.SetActive(false);
                portalActive = false;
                break;
        }
    }
}
