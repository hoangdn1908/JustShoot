using System;
using UnityEngine;

public class PlayerWalletController : MonoBehaviour
{

    public static event Action<int> OnTotalCoinChanged;
    public static PlayerWalletController Instance { get; private set; }
    private const string TotalCoinKey = "TotalCoin";
    public int TotalCoin {  get; private set; }

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
        PlayerPrefs.SetInt(TotalCoinKey, TotalCoin);
        PlayerPrefs.Save();
    }

    private void LoadCoin()
    {
        TotalCoin = PlayerPrefs.GetInt(TotalCoinKey, 0);
        OnTotalCoinChanged?.Invoke(TotalCoin);
    }
}
