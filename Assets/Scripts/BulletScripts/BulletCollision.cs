using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private BulletController bulletController;
    private float damage;

    public void SetDamage(float damage) 
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            bulletController.ReturnToPool();
        }
    }
}
