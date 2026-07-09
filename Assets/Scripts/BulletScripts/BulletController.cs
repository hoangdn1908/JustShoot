using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;

    public void Fire(Vector2 direction) 
    {
        rb.linearVelocity = direction.normalized * speed;
    }
}
