using System.Collections;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int points = 1; // Private field

    // Public property to access points
    public int Points
    {
        get { return points; }
        private set { points = value; }
    }

    private float invincibilityTime = 0.1f;
    private bool isInvincible = false;

    [SerializeField]
    private TextMeshProUGUI playerHealthText;

    [SerializeField]
    private TextMeshProUGUI staticSpriteText;

    // This method is called when the collider enters a trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"OnTriggerEnter2D called with Collider: {other.name}");
        if (other.CompareTag("Projectile") && !isInvincible)
        {
            Points--; // Use the public property
            Debug.Log($"Projectile hit. Remaining points: {Points}");
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

            // Notify GameManager to update health
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager?.UpdateHealth(gameObject, Points);
        }
    }

    // Update the player's health text UI
    void UpdatePlayerHealthText()
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = "Player Health: " + Points;
            Debug.Log($"Player health updated to: {Points}");
        }
    }

    // Update the static sprite's health text UI
    void UpdateStaticSpriteHealthText()
    {
        if (staticSpriteText != null)
        {
            staticSpriteText.text = "Base Health: " + Points;
            Debug.Log($"StaticSprite health updated to: {Points}");
        }
    }

    // Coroutine to handle invincibility after being hit
    IEnumerator Invincibility()
    {
        isInvincible = true;
        Debug.Log("Invincibility started.");
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
        Debug.Log("Invincibility ended.");
    }
}
