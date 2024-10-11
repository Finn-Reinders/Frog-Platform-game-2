using UnityEngine;

public class FrogHealth : MonoBehaviour
{
    public float health = 3f; // Total health of the frog

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Frog takes damage! Health: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Frog has died!");
        // Handle death (e.g., game over logic, animations, etc.)
    }
}
