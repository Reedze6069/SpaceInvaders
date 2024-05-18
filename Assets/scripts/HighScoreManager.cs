using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    [SerializeField]
    private float bestTime; // Private variable

    public float BestTime
    {
        get => bestTime;
        private set => bestTime = value;
    }

    public HighScoreData(float time)
    {
        BestTime = time;
    }
}

public class HighScoreManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScoreDataKey";

    // Save high score data
    public void SaveHighScore(float time)
    {
        PlayerPrefs.SetFloat(HighScoreKey, time);
        PlayerPrefs.Save();
        Debug.Log($"High score saved: {time}s");
    }

    // Load high score data
    public float LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            float highScore = PlayerPrefs.GetFloat(HighScoreKey);
            Debug.Log($"High score loaded: {highScore}s");
            return highScore;
        }

        Debug.Log("No high score data found.");
        return 0f; // Default value if no high score is found
    }

    // Reset high score data (optional utility method)
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(HighScoreKey);
        PlayerPrefs.Save();
        Debug.Log("High score reset.");
    }
}
