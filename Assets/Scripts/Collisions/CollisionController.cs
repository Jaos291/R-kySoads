using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private string _tagToCompare;

    [SerializeField] private bool _destroyer;

    [SerializeField] private bool _endOfGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare) && !_destroyer)
        {
            other.gameObject.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare) && !_destroyer)
        {
            other.gameObject.GetComponent<PlayerMovement>().isGrounded = false;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            Debug.Log("In");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            Debug.Log("Out");
        }
    }*/
}
