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
        
        /*Vector3 nextPosition = _camera.transform.position + Vector3.right* moveSpeed * Time.deltaTime;

        // Clamp the X-coordinate of the next position to stay within the boundary
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minBoundary, _maxBoundaryX);

        // Update the position of the camera
        _camera.transform.position = nextPosition;*/
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
        /*Vector3 nextPosition = _camera.transform.position + Vector3.right* moveSpeed * Time.deltaTime;

        // Clamp the X-coordinate of the next position to stay within the boundary
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minBoundary, _maxBoundaryX);

        // Update the position of the camera
        _camera.transform.position = nextPosition;*/
    }
}
