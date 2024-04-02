using UnityEngine;
using TMPro;

public class TimerLogic : MonoBehaviour
{
    public TMP_Text minutesText;
    public TMP_Text secondsText;
    public TMP_Text millisecondsText;

    private bool raceStarted = false;
    private float raceTime = 0f;
    private float recordTime;

    private void Start()
    {
        // Get the name of the current scene
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Load previous record time from PlayerPrefs with scene name as part of the key
        recordTime = PlayerPrefs.GetFloat("RecordTime_" + sceneName, 0f);
    }

    private void Update()
    {
        if (GameController.Instance.CanPlay)
        {
            raceTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt((raceTime / 60f) % 60f);
        int seconds = Mathf.FloorToInt(raceTime % 60f);
        int milliseconds = Mathf.FloorToInt((raceTime - Mathf.Floor(raceTime)) * 1000f);

        // Update UI text
        minutesText.text = minutes.ToString("00") + ":";
        secondsText.text = seconds.ToString("00") + ":";
        millisecondsText.text = milliseconds.ToString("000");
    }


    public void EndRace()
    {
        GameController.Instance.CanPlay = false;

        // Check if the current race time beats the record time
        if (raceTime < recordTime || recordTime == 0f)
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            // Save new record time to PlayerPrefs
            PlayerPrefs.SetFloat("RecordTime_" + sceneName, raceTime);
            PlayerPrefs.Save();
        }
    }

    public void StartRace()
    {
        // Reset race time and start the timer
        raceTime = 0f;
        raceStarted = true;
    }

    public void ResetTimerUI()
    {
        raceTime = 0f;
        // Reset the timer UI to display zero time
        minutesText.text = "00:";
        secondsText.text = "00:";
        millisecondsText.text = "000";
    }
}
