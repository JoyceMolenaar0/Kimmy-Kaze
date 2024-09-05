using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{

    Scene sceneLoaded = SceneManager.GetActiveScene();
    // loads next level
    
    public int sceneID = SceneManager.GetActiveScene().buildIndex;
    public Transform target;
    public float proximityThreshold = 5f;
    public int nextScene = 0;

    private void Start()
    {
        nextScene = sceneID + 1;
    }
    void Update()
    {
        DetectProximity();
        
        Debug.Log(nextScene);
    }

    void DetectProximity()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if ((distance <= proximityThreshold) && (Input.GetKeyDown(KeyCode.Q)))
            {
                Debug.Log("Explode");
                SceneManager.LoadScene(sceneLoaded.buildIndex + 1);

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
