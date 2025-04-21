using UnityEngine;
using UnityEngine.UI; // 或者使用 TMPro
using TMPro;

public class TutorialSequence : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;
    public GameTimer gameTimer;

    private string[] tutorialMessages = new string[]
    {
        "Welcome to LEARNINGVR!",
        "Use W A S D To Move",
        "Space to Jump",
        "Shift to Accelerate",
        "Find Coins To Get Score",
        "When Score is 20,Win!",
        "Use Mouse To Look Around",
        "Notice Something Happened When Fall Down to Trap",
        "Now Press any key to start the game",
    };

    private int currentMessageIndex = 0;
    private bool tutorialActive = true;

    void Start()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        tutorialText.text = tutorialMessages[0];
    }

    void Update()
    {
        if (tutorialActive && Input.anyKeyDown)
        {
            currentMessageIndex++;
            if (currentMessageIndex < tutorialMessages.Length)
            {
                tutorialText.text = tutorialMessages[currentMessageIndex];
            }
            else
            {
                EndTutorial();
            }
        }
    }

    void EndTutorial()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏
        tutorialActive = false;

        gameTimer.StartTimer();
    }
}