using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public static Action<float, float> OnHealthChanged;
    private PlayerController playerController;
    private float currentHealth;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        SetCurrentHealth();
    }

    private void SetCurrentHealth() 
    {
        currentHealth = playerController.playerData.maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        if (!IsAlive()) return;
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        SetHealthChanged();
    }

    public bool IsAlive() 
    {
        return currentHealth > 0;
    }
    private void SetHealthChanged()
    {
        OnHealthChanged?.Invoke(currentHealth, playerController.playerData.maxHealth);
    }

}
