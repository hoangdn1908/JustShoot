using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static Action<int> OnEnemyDied;
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
        ListenToEnemyDiedAndAddRandomCoin();
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void ListenToEnemyDiedAndAddRandomCoin() 
    {
        if (IsAlive()) return;
        OnEnemyDied?.Invoke(UnityEngine.Random.Range(1, 5));
    }
}
