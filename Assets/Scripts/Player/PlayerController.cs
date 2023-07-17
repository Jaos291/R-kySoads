using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _oxygen;

    [SerializeField] private float _oxygenMultiplier;


    //-----------------------
    [HideInInspector] public float Oxygen => _oxygen;

    [HideInInspector] public float OxygenMultiplier => _oxygenMultiplier;


    public void DepletOxigen(float multiplier)
    {
        
    }
}
