using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        Timer timer = FindObjectOfType<Timer>();
        PlayerPrefs.SetFloat("ElapsedTime", timer.ElapsedTime);
        
        // Save high score
        HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();
        if (highScoreManager != null)
        {
            float currentHighScore = highScoreManager.LoadHighScore();
            if (timer.ElapsedTime > currentHighScore)
            {
                highScoreManager.SaveHighScore(timer.ElapsedTime);
                Debug.Log($"New High Score: {timer.ElapsedTime}s");
            
            }
        }
        StartCoroutine(LoadGameOverSceneDelayed());
    }
    IEnumerator LoadGameOverSceneDelayed()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("GameOverScene");
    }
}