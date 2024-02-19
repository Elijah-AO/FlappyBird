using UnityEngine;

public class BounceDirection2D : MonoBehaviour
{
    public float bounceStrength = 5f; // Adjust the strength of the bounce
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) // Make sure the ground has a "Ground" tag
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            
            // Determine direction: use Vector2.right for right, Vector2.left for left
            Vector2 bounceDirection = Vector2.right; // or Vector2.left
            
            // Apply the bounce force
            rb.AddForce(Vector2.right * 2f, ForceMode2D.Impulse);
        }
    }
}