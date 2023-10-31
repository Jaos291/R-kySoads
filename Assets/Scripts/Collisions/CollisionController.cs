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
            }else if (_destroyer)
            {
                Destroy(collision.gameObject);
            }else if (_oxygenBurner)
            {
                Debug.Log("Oxygen Depleting!");
            }else if (_slower)
            {
                Debug.Log("Slowing!");
            }
        }
    }
}
