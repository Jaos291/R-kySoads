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

}
