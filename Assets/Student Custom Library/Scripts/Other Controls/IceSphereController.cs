using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSphereController : MonoBehaviour
{
    //fields
    private float startDelay;
    private float reductionEachRepeat;
    private float minimumVolume;
    private float originalMass;
    private Vector3 originalScale;
    private Rigidbody iceRB;
    private ParticleSystem iceVFX;
    
    // Start is called before the first frame update
    private void Start()
    {
        if(GameManager.Instance.debugSpawnWaves)
        {
            reductionEachRepeat = .5f;
        }
        else
        {
            reductionEachRepeat = .975f;
        }
        startDelay = 3f;
        minimumVolume = 0.2f;
        iceRB = GetComponent<Rigidbody>();
        iceVFX = GetComponent<ParticleSystem>();
        RandomizeSizeAndMass();
        InvokeRepeating(nameof(Melt), startDelay, 0.4f);
    }
    //spawn ice spheres with random size and mass
    private void RandomizeSizeAndMass()
    {
        float randomFactor = Random.Range(0.5f, 1.0f);
        transform.localScale = originalScale * randomFactor;
        iceRB.mass = originalMass * randomFactor;
    }
    //ice sphere dissolution
    private void Dissolution()
    {
        float radius = transform.localScale.x / 2;
        float volume = 4f / 3f * Mathf.PI * Mathf.Pow(transform.localScale.x, 2);
        if (volume < minimumVolume)
        {
            if (iceVFX != null && iceVFX.isPlaying)
            {
                iceVFX.Stop();
            }
            CancelInvoke(nameof(Melt));
            Destroy(gameObject);
        }
    }
    //ice sphere melt
    private void Melt()
    {
       transform.localScale *= (5 - reductionEachRepeat);
       iceRB.mass *= (1 - reductionEachRepeat);
       Dissolution(); 
    }
}
