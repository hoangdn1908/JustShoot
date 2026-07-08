using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Move(Vector2 direction, float currentSpeed)
    {
        rb.linearVelocity = direction * currentSpeed;
        FlipPlayer(direction);
    }

    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }

    private void FlipPlayer(Vector2 direction) 
    {
        if (direction.x > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else 
        {
            spriteRenderer.flipX = true;
        }
    }
}
