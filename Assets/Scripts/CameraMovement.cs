using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _cameraPositions;

    [SerializeField] private Camera _camera;


    private void Start()
    {
        MoveCamera();
    }
    private void MoveCamera()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.75f);
        GameController.Instance._musicAndSFXController.ChangeClip(
            GameController.Instance._musicAndSFXController.currentClip[0],
            false
            );
        LeanTween.move(_camera.gameObject, _cameraPositions[0], 4.5f);
        yield return new WaitForSeconds(4.75f);
        LeanTween.rotate(_camera.gameObject, new Vector3(_cameraPositions[0].transform.rotation.x, 0,0), 0.25f);
    }

    public void RestartLevelCamera()
    {
        _camera.transform.position = _cameraPositions[0].position;
    }
}
