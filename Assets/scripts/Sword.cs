using System.Collections;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float attackRange = 2f; // Adjust the attack range as needed
    public LayerMask enemyLayer; // Set the layer for enemies

    private bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isAttacking)
        {
            StartCoroutine(PerformSwordAttack());
        }
    }

    IEnumerator PerformSwordAttack()
    {
        isAttacking = true;

        // Perform a 180-degree attack using OverlapCircleAll
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            // You can add more logic here for dealing damage to enemies
            Debug.Log("Hit enemy: " + enemy.name);
        }

        // Optional: You can add animation or sound effects here

        yield return new WaitForSeconds(0.2f); // Adjust this delay as needed

        isAttacking = false;
    }

    // Visualize the attack range in the scene view (for debugging)
    private void OnDrawGizmosSelected()
    {
        DrawArc(transform.position, transform.up, transform.right, 180f, attackRange);
    }

    // Custom method to draw an arc
    private void DrawArc(Vector3 center, Vector3 forward, Vector3 right, float angle, float radius)
    {
        int segments = 100;
        float step = angle / segments;
        float halfAngle = angle * 0.5f;

        for (int i = 0; i <= segments; i++)
        {
            float t = Mathf.Deg2Rad * (i * step - halfAngle);
            Vector3 pointA = center + right * Mathf.Cos(t) * radius + forward * Mathf.Sin(t) * radius;
            t = Mathf.Deg2Rad * ((i + 1) * step - halfAngle);
            Vector3 pointB = center + right * Mathf.Cos(t) * radius + forward * Mathf.Sin(t) * radius;

            Gizmos.DrawLine(pointA, pointB);
        }
    }
}