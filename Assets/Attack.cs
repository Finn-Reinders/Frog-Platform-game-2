using UnityEngine;
using System.Collections;

public class FrogAttack : MonoBehaviour
{
    public GameObject tonguePrefab;       // The tongue GameObject to spawn when attacking
    public Transform tongueOrigin;        // The point from which the tongue will extend
    public float tongueLength = 3f;       // Maximum length of the tongue
    public float tongueSpeed = 5f;        // Speed at which the tongue extends/retracts
    public float attackCooldown = 1f;     // Cooldown time between attacks

    private GameObject currentTongue;     // Reference to the current tongue instance
    private bool isAttacking = false;     // Whether the frog is currently attacking
    private float attackTime;             // Time when the last attack happened

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking && Time.time >= attackTime + attackCooldown)
        {
            // Start the attack when the left mouse button is clicked, and if not in cooldown
            StartCoroutine(ExtendTongue());
            attackTime = Time.time; // Set the attack time for cooldown tracking
        }
    }

    private IEnumerator ExtendTongue()
    {
        isAttacking = true;

        // Instantiate the tongue at the frog's mouth (tongueOrigin)
        currentTongue = Instantiate(tonguePrefab, tongueOrigin.position, tongueOrigin.rotation);

        // Extend the tongue to the target length
        float currentLength = 0f;
        while (currentLength < tongueLength)
        {
            currentLength += tongueSpeed * Time.deltaTime;
            currentTongue.transform.localScale = new Vector3(currentLength, 0.1f, 1f); // Adjust size for tongue growth
            currentTongue.transform.position = tongueOrigin.position + tongueOrigin.right * (currentLength / 2f); // Position tongue correctly
            yield return null;
        }

        // Wait for a short time before retracting
        yield return new WaitForSeconds(0.5f);

        // Retract the tongue
        while (currentLength > 0f)
        {
            currentLength -= tongueSpeed * Time.deltaTime;
            currentTongue.transform.localScale = new Vector3(currentLength, 0.1f, 1f);
            currentTongue.transform.position = tongueOrigin.position + tongueOrigin.right * (currentLength / 2f);
            yield return null;
        }

        Destroy(currentTongue); // Destroy the tongue after the attack
        isAttacking = false;
    }
}
