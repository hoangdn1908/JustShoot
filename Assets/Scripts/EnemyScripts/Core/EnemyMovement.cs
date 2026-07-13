using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Transform target;

    public void SetTarget(Transform target) 
    {
        this.target = target;
    }

    public void MoveToTarget(float speed) 
    {
        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        rb.linearVelocity = direction * speed;
        FlipEnemy(direction);
    }

    public void Stop() 
    {
        rb.linearVelocity = Vector2.zero;
    }

    public void FlipEnemy(Vector2 direction) 
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
