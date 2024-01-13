using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float oxygen;
    public float fuel;

    public float oxygenDecreaseRate = 1f;
    public float fuelDecreaseRate = 1f;
    public float deAccelerationRate = 5f;

    public float currentSpeed = 0f;

    public bool moving=false;
    private bool isPlaneMoving;
    private float oxygenOriginalValue;
    private float fuelOriginalValue;

    private void Start()
    {
        oxygenOriginalValue = 100f;
        fuelOriginalValue = 100f;
        moving = false;
    }

    public void RestartValues()
    {
        oxygen = 100f;
        fuel = 100f;
    }

    private void LateUpdate()
    {
        if (GameController.Instance.CanPlay)
        {
            DecreaseOxygen();

            DecreaseFuel();
        }
    }

    private void DecreaseOxygen()
    {
        oxygen -= oxygenDecreaseRate * Time.deltaTime;

        oxygen = Mathf.Clamp(oxygen , 0f, oxygenOriginalValue);

        if (oxygen <= 0f)
        {
            GameController.Instance.PlayerDied(this.gameObject, false);
        }
    }

    public void DecreaseFuel()
    {
        if (PlaneMovement.planeMoving)
        {

            fuel -= fuelDecreaseRate * Time.deltaTime;

            fuel = Mathf.Clamp(fuel,0f,fuelOriginalValue);

            if (fuel <= 0)
            {
                PlaneMovement.slowing = true;
                currentSpeed = Deaccelerate();
            }

            if (currentSpeed<=0)
            {
                currentSpeed = 0;
                PlaneMovement.planeSpeed = currentSpeed;
                GameController.Instance.LostState();
            }
        }
    }

    public float Deaccelerate()
    {
        float newSpeed = Mathf.Max(0f, currentSpeed - deAccelerationRate * Time.deltaTime);

        return newSpeed;
    }
}
