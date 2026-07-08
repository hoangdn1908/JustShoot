using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public void Move(Vector2 direction, float currentSpeed)
    {
        rb.linearVelocity = direction * currentSpeed;
    }

    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
