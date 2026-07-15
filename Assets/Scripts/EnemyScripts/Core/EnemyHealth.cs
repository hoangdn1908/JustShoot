using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    private EnemyController enemyController;
    private float currentHealth;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public void SetCurrentHealth()
    {
        currentHealth = enemyController.EnemyData.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!IsAlive()) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
