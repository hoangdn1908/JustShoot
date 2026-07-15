using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField, Min(0.01f)] private float damageInterval = 0.5f;
    private EnemyController enemyController;
    private float nextDamageTime;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (Time.time < nextDamageTime) return;
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(enemyController.EnemyData.damage);
            nextDamageTime = Time.time + damageInterval;
        }
    }
}
