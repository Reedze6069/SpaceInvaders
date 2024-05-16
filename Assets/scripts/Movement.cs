using UnityEngine;
using TMPro;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int maxProjectiles = 6;
    private int currentProjectiles;
    [SerializeField] private TextMeshProUGUI projectileText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private float yOffset = 0.5f;

    private Animator animator;

    void Start()
    {
        SetupLivesText();
        SetInitialPosition();
        currentProjectiles = maxProjectiles;
        UpdateUIText();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void SetupLivesText()
    {
        GameObject livesObject = new GameObject("LivesText");
        livesObject.transform.SetParent(transform);
        livesObject.transform.localPosition = new Vector3(0f, 2f, 0f);
        livesText = livesObject.AddComponent<TextMeshProUGUI>();
        livesText.fontSize = 6;
        livesText.alignment = TextAlignmentOptions.Center;
        livesText.color = Color.white;
    }

    private void SetInitialPosition()
    {
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }

    void Shoot()
    {
        if (currentProjectiles > 0)
        {
            animator.SetTrigger("SwipeTrigger");
            Instantiate(projectilePrefab, transform.position + Vector3.up * yOffset, Quaternion.identity);
            currentProjectiles--;
            UpdateUIText();
        }
    }

    public void EnemyDestroyed()
    {
        currentProjectiles = Mathf.Min(currentProjectiles + 1, maxProjectiles);
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        projectileText.text = $" {currentProjectiles}/{maxProjectiles}";
        UpdateUITextPosition();
    }

    private void UpdateUITextPosition()
    {
        projectileText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 1f, 0f));
        livesText.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 2f, 0f));
    }

    public void ReturnProjectile()
    {
        EnemyDestroyed(); // Uses the same logic to increase projectiles
    }
}
