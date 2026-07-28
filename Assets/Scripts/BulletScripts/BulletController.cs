using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float timeLive;
    [SerializeField] private Rigidbody2D rb;
    private ObjectPool pool;
    private float timer;
    private float speed;
    private BulletCollision bulletCollision;

    private void Awake()
    {
        bulletCollision = GetComponent<BulletCollision>();
    }

    private void Update()
    {
        CheckTimeLive();
    }

    private void SetSpeed(float speed) 
    {
        this.speed = speed;
    }

    private void SetPool(ObjectPool pool) 
    {
        this.pool = pool;
    }

    public void Fire(Vector2 direction) 
    {
        rb.linearVelocity = direction.normalized * speed;
    }

    public void PrepareBeforeShoot(float speed, ObjectPool pool, float damage) 
    {
        SetSpeed(speed);
        SetPool(pool);
        bulletCollision.SetDamage(damage);
    }

    private void CheckTimeLive() 
    {
        timer += Time.deltaTime;
        if (timer >= timeLive) 
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool() 
    {
        timer = 0;
        rb.linearVelocity = Vector2.zero;
        pool.ReturnToPool(gameObject);
    }
}
