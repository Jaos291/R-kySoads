using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private string _tagToCompare;

    [SerializeField] private bool _destroyer;

    [SerializeField] private bool _endOfGame;

    [SerializeField] private bool _oxygenBurner;

    [SerializeField] private bool _slower;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare))
        {
            if (!_destroyer && ! _endOfGame)
            {
                other.gameObject.GetComponent<PlayerMovement>().isGrounded = true;
            }
            else if (!_destroyer && _endOfGame)
            {
                Debug.Log("EndGame!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare))
        {
            if (!_destroyer && !_endOfGame)
            {
                other.gameObject.GetComponent<PlayerMovement>().isGrounded = false;
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            if (!_destroyer && !_endOfGame)
            {
                collision.gameObject.GetComponent<PlayerMovement>().isGrounded = true;
            }
            else if (!_destroyer && _endOfGame)
            {
                Debug.Log("EndGame!");
            }
        }
        if (collision.gameObject.tag.Equals(_tagToCompare) && _destroyer)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            if (!_destroyer && !_endOfGame)
            {
                collision.gameObject.GetComponent<PlayerMovement>().isGrounded = false;
            }
        }
    }

    /* private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            Debug.Log("Out");
        }
    }*/
}
