using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float _planeSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //_rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.x, _planeSpeed);
    }
}
