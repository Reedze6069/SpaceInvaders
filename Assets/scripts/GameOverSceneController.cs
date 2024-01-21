using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverSceneController : MonoBehaviour
{
    public TextMeshProUGUI timeSurvivedText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        // Retrieve the elapsed time from PlayerPrefs
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        // Display the time survived in a TextMeshProUGUI component
        if (timeSurvivedText != null)
        {
            timeSurvivedText.text = $"Time Survived: {Mathf.RoundToInt(elapsedTime)}s";
        }
        else
        {
            Debug.LogError("Please assign a TextMeshProUGUI component to the timeSurvivedText field in the inspector.");
        }

        // Retrieve and display the high score
        HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();
        if (highScoreManager != null)
        {
            float highScore = highScoreManager.LoadHighScore();
            if (highScoreText != null)
            {
                highScoreText.text = $"High Score: {Mathf.RoundToInt(highScore)}s";
            }
            else
            {
                Debug.LogError("Please assign a TextMeshProUGUI component to the highScoreText field in the inspector.");
            }
        }
    }

    // Call this method from the "Play Again" button
    public void PlayAgain()
    {
        // Reset any necessary game state here

        // Load the SampleScene
        SceneManager.LoadScene("SampleScene");
    }

    // Add any other necessary logic for your GameOverScene...
}
