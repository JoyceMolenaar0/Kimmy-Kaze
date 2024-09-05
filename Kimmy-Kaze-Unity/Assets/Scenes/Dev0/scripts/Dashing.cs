using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{

    ThirdPersonMovement ThirdPersonMovement;

    public float dashSpeed;
    public float dashTime;

    void Start()
    {
        ThirdPersonMovement = GetComponent<ThirdPersonMovement>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            ThirdPersonMovement.controller.Move(ThirdPersonMovement.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
