using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private BulletController bulletController;
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (collision.CompareTag("Enemy")) 
        {
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                bulletController.ReturnToPool();
            }
        }
    }
}
