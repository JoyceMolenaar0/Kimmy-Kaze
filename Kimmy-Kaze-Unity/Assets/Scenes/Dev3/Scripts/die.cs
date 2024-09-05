using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public Transform target;
    public float proximityThreshold = 5f;

    void Update()
    {
        DetectProximity();
    }

    void DetectProximity()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if ((distance <= proximityThreshold) && (Input.GetKeyDown(KeyCode.Space)))
            {
                Debug.Log("Explode");
            }
            else if (distance <= proximityThreshold)
            {
                Debug.Log("Target is within proximity!");
            }
            else
            {
                Debug.Log("Target is outside proximity.");
            }
        }
        else
        {
            Debug.LogError("Target is not assigned!");
        }
    }
}
