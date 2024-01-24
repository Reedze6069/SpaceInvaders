using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public int points = 1;
    private float invincibilityTime = 0.1f;
    private bool isInvincible = false;
    private bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI playerHealthText;

    [SerializeField]
    private TextMeshProUGUI staticSpriteText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile") && isInvincible == false)
        {
            points--;
            StartCoroutine(Invincibility());
            Destroy(other.gameObject);

            if (gameObject.CompareTag("Player"))
            {
                UpdatePlayerHealthText();
            }
            else if (gameObject.CompareTag("StaticSprite"))
            {
                UpdateStaticSpriteHealthText();
            }
        }

        if (points <= 0 && !isGameOver)
        {
            isGameOver = true;

            if (gameObject.CompareTag("Player") || gameObject.CompareTag("StaticSprite"))
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager?.GameOver();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void UpdatePlayerHealthText()
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = "Player Health: " + points.ToString();
        }
    }

    void UpdateStaticSpriteHealthText()
    {
        if (staticSpriteText != null)
        {
            staticSpriteText.text = "Base Health: " + points.ToString();
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
