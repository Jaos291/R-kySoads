using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMovement : MonoBehaviour
{
    public float planeSpeed;

    private const float _SPEED_CHANGER_AMOUNT = 1.25f;

    private float y;

    private void Update()
    {
        transform.Translate(Vector3.back * planeSpeed * Time.fixedDeltaTime);

        ChangeSetSpeed();
    }

    public void ChangeSetSpeed()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            planeSpeed += _SPEED_CHANGER_AMOUNT;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            planeSpeed -= _SPEED_CHANGER_AMOUNT;

            if (planeSpeed < 0)
            {
                planeSpeed = 0;
            }
        }
    }
}
