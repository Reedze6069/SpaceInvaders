using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public float bestTime;

    public HighScoreData(float time)
    {
        bestTime = time;
    }
}

public class HighScoreManager : MonoBehaviour
{
    private string highScoreKey = "HighScoreDataKey";

    // Save high score data
    public void SaveHighScore(float time)
    {
        HighScoreData highScoreData = new HighScoreData(time);
        string json = JsonUtility.ToJson(highScoreData);
        PlayerPrefs.SetString(highScoreKey, json);
        PlayerPrefs.Save();

        Debug.Log($"High score saved: {time}s");
    }

    // Load high score data
    public float LoadHighScore()
    {
        string json = PlayerPrefs.GetString(highScoreKey, "");
        if (!string.IsNullOrEmpty(json))
        {
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            Debug.Log($"High score loaded: {highScoreData.bestTime}s");
            return highScoreData.bestTime;
        }

        Debug.Log("No high score data found.");
        return 0f; // Default value if no high score is found
    }
}