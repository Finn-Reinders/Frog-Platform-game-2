using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpForce = 10f;           // Jump force
    private bool isGrounded;                // Whether the frog is on the ground
    private int jumpCount = 0;              // Number of jumps made
    public int maxJumps = 2;                // Maximum number of jumps allowed (2 for double jump)

    public Transform groundCheck;           // Ground check position (empty GameObject below frog)
    public float checkRadius = 0.2f;        // Radius for ground check overlap
    public LayerMask groundLayer;           // Layer to detect ground

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ground check logic - checking if the frog is grounded using OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Debugging ground check visualization
        Debug.DrawRay(groundCheck.position, Vector2.down * checkRadius, Color.red);
        Debug.Log("Is Grounded: " + isGrounded);

        // Reset the jump count when the frog is grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Jump input: Allow jump if frog is grounded or has not reached max jumps
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
            jumpCount++;  // Increment jump count each time the frog jumps
        }
    }

    void Jump()
    {
        // Apply the jump force upwards while maintaining horizontal velocity
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Debug: Log the jump force applied and the current jump count
        Debug.Log("Jump force applied: " + jumpForce + " | Jump Count: " + jumpCount);
    }
}
