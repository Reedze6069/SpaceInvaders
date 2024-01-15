using System.Collections;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isRunning = false;
    public TextMeshProUGUI stopwatchText;
    public Health healthScript;

    void Start()
    {
        UpdateUIText();
        StartCoroutine(RunStopwatch());
    }

    void UpdateUIText()
    {
        stopwatchText.text = $" {Mathf.RoundToInt(elapsedTime)}s";
    }

    IEnumerator RunStopwatch()
    {
        isRunning = true;

        while (isRunning)
        {
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
            UpdateUIText();
        }

        // Game over logic here
        if (healthScript.points <= 0)
        {
            isRunning = false;
            Debug.Log($"Stopwatch stopped. Elapsed time: {elapsedTime}s");
        }
    }
}