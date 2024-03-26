using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour,  IPointerClickHandler
{
    [SerializeField]private string SceneToChange;

    [SerializeField] private GameObject _fade;
    public void OnPointerClick(PointerEventData eventData)
    {
        FadeToScene();
    }

    public void FadeToScene()
    {
        StartCoroutine(Fade(SceneToChange));

    }

    IEnumerator Fade(string sceneToChange)
    {
        _fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Loader.Load(sceneToChange);
    }
}
