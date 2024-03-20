using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject _VictoryCanvas;

    [SerializeField] private GameObject _LostCanvas;

    [SerializeField] private string _tagToCompare;

    [SerializeField] private bool _destroyer;

    [SerializeField] private bool _endOfGame;

    [SerializeField] private bool _oxygenBurner;

    [SerializeField] private bool _slower;

    private enum State
    {
        Normal,
        Slowed,
        OxygenDepleting,
    }

    private void Awake()
    {
        if (_VictoryCanvas)
        {
            if (_VictoryCanvas.activeSelf)
            {
                _VictoryCanvas.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            if (!_destroyer && !_endOfGame)
            {
                collision.gameObject.GetComponent<PlayerMovement>().canJump = true;
                collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                LeanTween.cancel(collision.gameObject);
                LeanTween.rotate(collision.gameObject, new Vector3(0, 0), 0.1f);
            }
            else if (!_destroyer && _endOfGame)
            {
                VictoryState();
                GameController.Instance.PlayerDied(true);
            }
            else if (_destroyer)
            {
                GameController.Instance.PlayerDied(false);

            }
            else if (_oxygenBurner)
            {
                Debug.Log("Oxygen Depleting!");

            }else if (_slower)
            {
                Debug.Log("Slowing!");
            }
        }
    }

    private void VictoryState()
    {
        GameController.Instance.VictoryState();
    }
}
