using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText; // 或 TMP_Text
    private float elapsedTime = 0f;
    private bool timerRunning = false;

    void Update()
    {
        if (!timerRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timeText.text = string.Format("Game Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}