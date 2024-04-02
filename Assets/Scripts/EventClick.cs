using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class EventClick : MonoBehaviour,  IPointerClickHandler
{
    [SerializeField]private string SceneToChange;

    [SerializeField] private GameObject _fade;

    public TMP_Text stageRecord;

    private void Start()
    {
        float stageRecordValue = PlayerPrefs.GetFloat("RecordTime_" + SceneToChange,0f);
        if (stageRecordValue <= 0f)
        {
            stageRecord.text = "Best Time: 00:00:00";
        }
        else
        {
            int minutes = Mathf.FloorToInt(stageRecordValue / 60f);
            int seconds = Mathf.FloorToInt(stageRecordValue % 60f);
            int milliseconds = Mathf.FloorToInt((stageRecordValue - Mathf.Floor(stageRecordValue)) * 1000f);

            string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            stageRecord.text = "Best Time: " + formattedTime;
        }
        
    }
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
