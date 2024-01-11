using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //------------------

    public GameObject _player;

    public Transform playerStartingPoint;

    public bool CanPlay = false;

    [SerializeField] private GameObject _victory;

    [SerializeField] private SceneChanger sceneChanger;

    [SerializeField] private GameObject _fade;

    [SerializeField] private GameObject _VictoryCanvas;

    [SerializeField] private GameObject _LostCanvas;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke("SpawnPlayer",0f);
    }

    public void SpawnPlayer()
    {
        CanPlay = true;

        Instantiate(_player, playerStartingPoint);

        if (!_player.activeSelf)
        {
            _player.SetActive(true);
        }
    }

    public void PlayerDied(GameObject player)
    {
        player.gameObject.SetActive(false);
    }

    public void FadeAway()
    {
        _fade.SetActive(true);
    }

    public void VictoryState()
    {
        StartCoroutine(ReturnToStageSelectForWinning());
    }

    public void LostState()
    {
        StartCoroutine(ReturnToStageSelectForLosing());
    }

    IEnumerator ReturnToStageSelectForWinning()
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
    }

}
