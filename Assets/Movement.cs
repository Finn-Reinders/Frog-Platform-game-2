using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;           // Reference to the frog (target to attack)
    public float moveSpeed = 2f;       // Movement speed of the enemy
    public float attackRange = 1.5f;   // Distance within which the enemy will attack
    public float attackDamage = 1f;    // Damage inflicted on the frog

    private void Update()
    {
        if (target != null)
        {
            // Calculate the distance to the target (frog)
            float distance = Vector2.Distance(transform.position, target.position);

            // Move towards the target
            if (distance > attackRange)
            {
                MoveTowardsTarget();
            }
            else
            {
                Attack();
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // Move the enemy towards the target
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    private void Attack()
    {
        // Implement attack logic
        Debug.Log("Enemy attacks the frog!");
        // Here you could call a method on the frog to deal damage.
        // For example, if your frog has a health script, you can access it like this:
        // target.GetComponent<FrogHealth>().TakeDamage(attackDamage);
    }
}
