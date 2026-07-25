using System;
using UnityEngine;

public class PlayerWalletController : MonoBehaviour
{

    public static event Action<int> OnTotalCoinChanged;
    public static PlayerWalletController Instance { get; private set; }
    public int TotalCoin { get; private set; }

    private void Awake()
    {
        if (!TryInitializeSingleton()) return;
        LoadCoin();

    }

    private bool TryInitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return false;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        return true;
    }

    public void AddCoin(int amount) 
    {
        TotalCoin += amount;
        SaveCoin();
        OnTotalCoinChanged?.Invoke(TotalCoin);
    }

    private void SaveCoin()
    {
        if (GameSaveManager.Instance == null || GameSaveManager.Instance.Data == null)
            return;
        GameSaveManager.Instance.Data.totalCoin = TotalCoin;
        GameSaveManager.Instance.Save();
    }


    public bool TrySpendCoin(int amount) 
    {
        if (amount < 0) return false;
        if(amount > TotalCoin) return false;
        TotalCoin -= amount;
        SaveCoin();
        OnTotalCoinChanged?.Invoke(TotalCoin);
        return true;
    }

    private void LoadCoin()
    {
        if (GameSaveManager.Instance == null || GameSaveManager.Instance.Data == null)
        {
            TotalCoin = 0;
            OnTotalCoinChanged?.Invoke(TotalCoin);
            return;
        }
        TotalCoin = GameSaveManager.Instance.Data.totalCoin;
        OnTotalCoinChanged?.Invoke(TotalCoin);
    }
}
