using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeSurvivedText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        if (timeSurvivedText != null)
        {
            timeSurvivedText.text = $"Time Survived: {Mathf.FloorToInt(elapsedTime)}s";
        }
        else
        {
            Debug.LogError("Please assign a TextMeshProUGUI component to the timeSurvivedText field in the inspector.");
        }

        HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();
        if (highScoreManager != null)
        {
            float highScore = highScoreManager.LoadHighScore();
            if (highScoreText != null)
            {
                highScoreText.text = $"High Score: {Mathf.FloorToInt(highScore)}s";
            }
            else
            {
                Debug.LogError("Please assign a TextMeshProUGUI component to the highScoreText field in the inspector.");
            }
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
