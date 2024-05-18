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

        // Save high score
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

        // Start coroutine to load GameOverScene after a delay
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
                // If the game object is a player or static sprite, initiate game over
                Debug.Log("GameOver condition met for Player or StaticSprite.");
                GameOver();
            }
            else
            {
                // If the game object is not a player or static sprite, destroy it
                Debug.Log($"Destroying GameObject: {gameObject.name}");
                Destroy(gameObject);
            }
        }
    }
}
