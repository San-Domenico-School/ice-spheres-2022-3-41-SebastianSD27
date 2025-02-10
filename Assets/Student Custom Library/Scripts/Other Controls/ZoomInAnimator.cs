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

public class ZoomInAnimator : MonoBehaviour
{
    private Vector2 desiredScale;
    private Vector3 initialScale = Vector3.one.normalized;
    private float zoomInRate = 1.06f;
    private float zoomInFrequency = 0.03f;
    
    private void OnEnable()
    {
        desiredScale = transform.localScale * 2;
        initialScale = transform.localScale;
        transform.localScale = initialScale;
        InvokeRepeating(nameof(ZoomIn), 0f, zoomInFrequency);
    }

    // Update is called once per frame
    private void OnDisable()
    {
        CancelInvoke(nameof(ZoomIn));
        transform.localScale = initialScale;
    }

    private void ZoomIn()
    {
        Vector3 currentScale = transform.localScale;
        if (currentScale.magnitude < desiredScale.magnitude)
        {
            transform.localScale = currentScale + (Vector3.one * zoomInRate);
        }
        else
        {
            CancelInvoke(nameof(ZoomIn));
        }
    }
}
