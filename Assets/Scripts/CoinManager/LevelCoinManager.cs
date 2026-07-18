using System;
using UnityEngine;

public class LevelCoinManager : MonoBehaviour
{
    public static LevelCoinManager Instance { get; private set; }
    public static event Action<int> OnLevelCoinChanged;
    public int CurrentLevelCoin { get; private set; }

    private void Awake()
    {
        SetSignleTon();
    }
    private void Start()
    {
        ResetLevelCoin();
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDied += AddCoin;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDied -= AddCoin;
    }

    private void SetSignleTon()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddCoin(int amount)
    {
        CurrentLevelCoin += amount;
        OnLevelCoinChanged?.Invoke(CurrentLevelCoin);
    }

    public void ResetLevelCoin()
    {
        CurrentLevelCoin = 0;
        OnLevelCoinChanged?.Invoke(CurrentLevelCoin);
    }
}
