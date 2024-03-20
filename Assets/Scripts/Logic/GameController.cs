using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour { 
    public static GameController Instance;

    //------------------

    public GameObject _player;

    public GameObject PlayerShip;

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

    private PlaneMovement planeMovement;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        planeMovement = GameObject.Find("Floor").GetComponent<PlaneMovement>();
        Invoke("SpawnPlayer", 6.15f);
        FadeAway();
    }

    public void SpawnPlayer()
    {
        CanPlay = true;

        playerGO = Instantiate(_player, playerStartingPoint);
        if (!GameController.Instance._musicAndSFXController.audioSource.isPlaying)
        {
            GameController.Instance._musicAndSFXController.ChangeClip(
            GameController.Instance._musicAndSFXController.currentClip[1],
            true
            );
        }
        if (!_player.activeSelf)
        {
            _player.SetActive(true);
        }
        PlayerShip = playerGO.GetComponent<Referencer>().Player;
        PlayerShip.GetComponent<PlayerStats>().RestartValues();
        playerMovement = PlayerShip.GetComponent<PlayerMovement>();

    }

    public void PlayerDied(bool winner)
    {
        if (!winner)
        {
            GameObject explosive = Instantiate(explotion, new Vector3(PlayerShip.transform.position.x, PlayerShip.transform.position.y, PlayerShip.transform.position.z), Quaternion.identity);
            //explosive.SetActive(true);
            LostState();
        }
        else
        {
            PlayerShip.gameObject.SetActive(false);
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
        StartCoroutine(ReturnToSameLevel(PlayerShip));
    }

    IEnumerator ReturnToSameLevel(GameObject player)
    {
        Destroy(playerGO);
        _fadeOut.SetActive(true);
        /*PlayerShip.GetComponent<PlayerStats>().RestartValues();
        PlayerShip.SetActive(false);*/
        yield return new WaitForSeconds(2f);
        _fadeOut.SetActive(false);
        Camera camera = Camera.main;
        camera.GetComponent<CameraMovement>().RestartLevelCamera();
        planeMovement.RestartLevel();
        /*PlayerShip.SetActive(true);
        PlayerShip.transform.position = playerStartingPoint.position;*/
        SpawnPlayer();
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
