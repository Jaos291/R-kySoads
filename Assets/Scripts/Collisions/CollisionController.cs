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
                collision.gameObject.GetComponent<PlayerMovement>().isGrounded = true;
            }
            else if (!_destroyer && _endOfGame)
            {
                VictoryState();
                GameController.Instance.PlayerDied(collision.gameObject);
            }
            else if (_destroyer)
            {
                GameController.Instance.PlayerDied(collision.gameObject);
                LostState();

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
        //StartCoroutine(ReturnToStageSelectForWinning());
        GameController.Instance.VictoryState();
    }

    private void LostState()
    {
        //StartCoroutine(ReturnToStageSelectForLosing());
        GameController.Instance.LostState();
    }

    /*IEnumerator ReturnToStageSelectForWinning()
    {
        _VictoryCanvas.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<SceneChanger>().FadeToScene("StageSelect");
    }

    IEnumerator ReturnToStageSelectForLosing()
    {
        _LostCanvas.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<SceneChanger>().FadeToScene("StageSelect");
    }*/
}
