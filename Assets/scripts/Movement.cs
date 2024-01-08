using UnityEngine;
using TMPro;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public int maxProjectiles = 6;
    private int currentProjectiles;

    // Change the data type to TextMeshProUGUI
    public TextMeshProUGUI projectileText;
    public TextMeshProUGUI livesText;
    public float yOffset = 0.5f; // Adjust the offset value as needed

    void Start()
    {
        // Create a TextMeshProUGUI component as a child of the cube
        GameObject textObject = new GameObject("ProjectileText");
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = new Vector3(0f, 1f, 0f);
        projectileText = textObject.AddComponent<TextMeshProUGUI>();

        // Set other properties for TextMeshProUGUI
        projectileText.fontSize = 16;
        projectileText.alignment = TextAlignmentOptions.Center;
        projectileText.color = Color.white;

        // Create a TextMeshProUGUI component for lives
        GameObject livesObject = new GameObject("LivesText");
        livesObject.transform.SetParent(transform);
        livesObject.transform.localPosition = new Vector3(0f, 2f, 0f);
        livesText = livesObject.AddComponent<TextMeshProUGUI>();

        // Set other properties for TextMeshProUGUI for lives
        livesText.fontSize = 16;
        livesText.alignment = TextAlignmentOptions.Center;
        livesText.color = Color.white;

        // Set the boundaries based on the screen size
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

        currentProjectiles = maxProjectiles;

        // Update the UI text initially
        UpdateUIText();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        UpdateUITextPosition();
    }

    void Shoot()
    {
        if (currentProjectiles > 0)
        {
            Instantiate(projectilePrefab, transform.position + Vector3.up * yOffset, Quaternion.identity);
            currentProjectiles--;
            UpdateUIText();
        }
    }

    public void EnemyDestroyed()
    {
        // Increase the projectile count when an enemy is destroyed
        currentProjectiles++;
        currentProjectiles = Mathf.Min(currentProjectiles, maxProjectiles);

        // Update UI text
        UpdateUIText();
    }

    void UpdateUIText()
    {
        //projectileText.text = $"Projectiles: {currentProjectiles}/{maxProjectiles}";
        //livesText.text = $"Lives: {currentLives}/{maxLives}";
    }

    void UpdateUITextPosition()
    {
        Vector3 uiTextPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 1f, 0f));
        projectileText.transform.position = uiTextPosition;

        Vector3 livesTextPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 2f, 0f));
        livesText.transform.position = livesTextPosition;
    }

    // Method to return a projectile when an enemy is destroyed
    public void ReturnProjectile()
    {
        // Increase the projectile count when an enemy is destroyed
        currentProjectiles++;
        currentProjectiles = Mathf.Min(currentProjectiles, maxProjectiles);

        // Update UI text
        UpdateUIText();
    }
}