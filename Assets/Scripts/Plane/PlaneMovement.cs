using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMovement : MonoBehaviour
{
    public float planeSpeed;

    [SerializeField] private float _speedChangerAmount = 1.25f;

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
            MoreSpeed(_speedChangerAmount);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            LessSpeed(_speedChangerAmount);
        }
    }

    public void MoreSpeed(float speedChanger)
    {
        planeSpeed += speedChanger;
    }

    public void LessSpeed(float speedChanger)
    {
        planeSpeed -= speedChanger;

        if (planeSpeed < 0)
        {
            planeSpeed = 0;
        }
    }
}
