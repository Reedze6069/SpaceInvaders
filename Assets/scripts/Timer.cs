using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isRunning = false;
    public TextMeshProUGUI stopwatchText;

	public float ElapsedTime => elapsedTime;

    void Start()
    {
        UpdateUIText();
        StartCoroutine(RunStopwatch());
    }

    void UpdateUIText()
    {
        stopwatchText.text = $" {Mathf.RoundToInt(elapsedTime)}s";
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
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
        Health health = FindObjectOfType<Health>();
        if (health != null && health.points <= 0)
        {
            isRunning = false;

            Debug.Log($"Stopwatch stopped. Elapsed time: {elapsedTime}s");
        }
    }
}