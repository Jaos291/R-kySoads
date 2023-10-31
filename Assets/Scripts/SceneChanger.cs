using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject _fade;

    public void FadeToScene(string sceneToChange)
    {
        StartCoroutine(Fade(sceneToChange));
        
    }

    IEnumerator Fade(string sceneToChange)
    {
        _fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneToChange, LoadSceneMode.Single);
    }
}
