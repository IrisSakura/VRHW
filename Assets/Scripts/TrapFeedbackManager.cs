using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TrapFeedbackManager : MonoBehaviour
{
    public static TrapFeedbackManager Instance;

    public TextMeshProUGUI warningText;
    public float showTime = 2f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if (warningText != null)
            warningText.enabled = false;
    }

    public void ShowWarning(string message)
    {
        StartCoroutine(ShowWarningRoutine(message));
    }

    private IEnumerator ShowWarningRoutine(string message)
    {
        if (warningText != null)
        {
            warningText.text = message;
            warningText.enabled = true;
            yield return new WaitForSeconds(showTime);
            warningText.enabled = false;
        }
    }
}