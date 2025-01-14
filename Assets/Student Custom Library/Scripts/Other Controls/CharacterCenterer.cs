using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************************
* Attach this script to all character models contained within a character container.
* This script makes sure that when the charter enters the scene, it is centered inside its container.
*
* Sebastian Balakier
* 1/10/2025, Version 1.0
*******************************************************************/


public class CharacterCenterer : MonoBehaviour
{
    // Awake is called before the first frame update
    void Awake()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    
}
