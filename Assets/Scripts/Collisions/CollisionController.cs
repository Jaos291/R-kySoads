using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private string _tagToCompare;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare))
        {
            //other.gameObject.GetComponent<PlayerMovement>().grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare))
        {
            //other.gameObject.GetComponent<PlayerMovement>().grounded = false;
        }
    }
}
