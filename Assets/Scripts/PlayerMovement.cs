using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody _rb;

    private float x;

    [HideInInspector] public bool isGrounded = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(playerSpeed * x, _rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, jumpForce), ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
