using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float timeLife;
    [SerializeField] private Rigidbody2D rb;
    private ObjectPool pool;
    private float timer;
    private float speed;

    private void Update()
    {
        CheckLiveTime();
    }

    public void SetSpeed(float speed) 
    {
        this.speed = speed;
    }

    public void SetPool(ObjectPool pool) 
    {
        this.pool = pool;
    }

    public void Fire(Vector2 direction) 
    {
        rb.linearVelocity = direction.normalized * speed;
    }

    private void CheckLiveTime() 
    {
        timer += Time.deltaTime;
        if (timer >= timeLife) 
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
