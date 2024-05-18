using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("GameOver method called in GameManager.");

        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            PlayerPrefs.SetFloat("ElapsedTime", timer.ElapsedTime);
            Debug.Log($"Elapsed Time saved: {timer.ElapsedTime}s");
        }

        HighScoreManager highScoreManager = FindObjectOfType<HighScoreManager>();
        if (highScoreManager != null && timer != null)
        {
            float currentHighScore = highScoreManager.LoadHighScore();
            if (timer.ElapsedTime > currentHighScore)
            {
                highScoreManager.SaveHighScore(timer.ElapsedTime);
                Debug.Log($"New High Score: {timer.ElapsedTime}s");
            }
            else
            {
                Debug.Log($"Current High Score: {currentHighScore}s. No new high score.");
            }
        }

        StartCoroutine(LoadGameOverSceneDelayed());
    }

    IEnumerator LoadGameOverSceneDelayed()
    {
        Debug.Log("Loading GameOverScene after delay.");
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("GameOverScene");
    }

    public void UpdateHealth(GameObject gameObject, int health)
    {
        Debug.Log($"UpdateHealth called with GameObject: {gameObject.name}, Health: {health}");
        if (health <= 0)
        {
            if (gameObject.CompareTag("Player") || gameObject.CompareTag("StaticSprite"))
            {
                Debug.Log("GameOver condition met for Player or StaticSprite.");
                GameOver();
            }
            else
            {
                Debug.Log($"Destroying GameObject: {gameObject.name}");
                Destroy(gameObject);
            }
        }
    }
}
