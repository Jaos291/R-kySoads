using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour { 
    public static GameController Instance;

    //------------------

    public GameObject _player;

    public Transform playerStartingPoint;

    public bool CanPlay = false;

    [SerializeField] private GameObject _fadein;

    [SerializeField] private GameObject _fadeOut;

    [SerializeField] private GameObject _VictoryCanvas;

    [SerializeField] private GameObject _LostCanvas;

    public StageConfigurationSO StageConfigurationSO;

    public MusicAndSFXController _musicAndSFXController;

    public GameObject explotion;

    private PlayerMovement playerMovement;

    private GameObject playerGO;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke("SpawnPlayer", 6.15f);
        FadeAway();
    }

    public void SpawnPlayer()
    {
        CanPlay = true;

        playerGO = Instantiate(_player, playerStartingPoint);
        GameController.Instance._musicAndSFXController.ChangeClip(
            GameController.Instance._musicAndSFXController.currentClip[1],
            true
            );
        if (!_player.activeSelf)
        {
            _player.SetActive(true);
        }
        _player.GetComponent<Referencer>().Player.GetComponent<PlayerStats>().RestartValues();
        playerMovement = playerGO.transform.GetChild(0).gameObject.GetComponent<PlayerMovement>();

    }

    public void PlayerDied(GameObject player, bool winner)
    {
        if (!winner)
        {
            GameObject explosive = Instantiate(explotion, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
            //explosive.SetActive(true);
            player.gameObject.SetActive(false);
            LostState();
        }
        else
        {
            player.gameObject.SetActive(false);
        }
    }

    public void RestartPlayer(GameObject player)
    {
        player.gameObject.SetActive(true);
    }

    public void PlayerJumped()
    {
        if (playerMovement)
        {
            playerMovement.Jump();
        }
    }

    public void FadeAway()
    {
        _fadein.SetActive(true);
    }

    public void VictoryState()
    {
        StartCoroutine(ReturnToStageSelectForWinning());
    }

    public void LostState()
    {
        StartCoroutine(ReturnToSameLevel());
    }

    IEnumerator ReturnToSameLevel()
    {
        _fadeOut.SetActive(true);
        _player.GetComponent<Referencer>().Player.GetComponent<PlayerStats>().RestartValues();
        yield return new WaitForSeconds(2f);
        _fadeOut.SetActive(false);
        Camera camera = Camera.main;
        camera.GetComponent<CameraMovement>().RestartLevelCamera();
        _player.gameObject.SetActive(true);
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
