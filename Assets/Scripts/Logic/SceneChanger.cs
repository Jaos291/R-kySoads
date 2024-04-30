using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject _fade;
    [SerializeField] private Camera _camera;
    [SerializeField] private float moveSpeed;

    private float _maxBoundaryX = 500f;
    private float _minBoundary = 128f;

    private string positionKey = "SavedCameraPosition";
    private string sceneName;


    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;

        if (sceneName.Equals("StageSelect") && _camera)
        {
            if (PlayerPrefs.HasKey(positionKey))
            {
                // Load saved position and rotation
                Vector3 savedPosition = StringToVector3(PlayerPrefs.GetString(positionKey));
                // Apply saved position and rotation to the camera
                _camera.transform.position = savedPosition;
            }
        }
    }

    void OnDestroy()
    {
        if (sceneName.Equals("StageSelect") && _camera)
        {
            // Save camera position and rotation when leaving the scene
            PlayerPrefs.SetString(positionKey, Vector3ToString(_camera.transform.position));
            PlayerPrefs.Save();
        }
    }

    private string Vector3ToString(Vector3 vector)
    {
        return vector.x + "," + vector.y + "," + vector.z;
    }

    private Vector3 StringToVector3(string str)
    {
        string[] parts = str.Split(',');
        float x = float.Parse(parts[0]);
        float y = float.Parse(parts[1]);
        float z = float.Parse(parts[2]);
        return new Vector3(x, y, z);
    }

    public void FadeToScene(string sceneToChange)
    {
        StartCoroutine(Fade(sceneToChange));
        
    }

    IEnumerator Fade(string sceneToChange)
    {
        _fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Loader.Load(sceneToChange);
    }

    public void MoveCameraLeft()
    {
        if (_camera.transform.position.x <= 223)
        {
            LeanTween.moveX(_camera.gameObject, _camera.transform.position.x - 0f, 0.5f);
        }
        else
        {
            LeanTween.moveX(_camera.gameObject, _camera.transform.position.x - moveSpeed, 0.5f);
        }
        
    }

    public void MoveCameraRight()
    {
        if (_camera.transform.position.x >= 3023)
        {
            LeanTween.moveX(_camera.gameObject, _camera.transform.position.x - 0f, 0.5f);
        }
        else
        {
            LeanTween.moveX(_camera.gameObject, _camera.transform.position.x + moveSpeed, 0.5f);
        }
    }
}
