using TMPro;
using UnityEngine;

public class PlayerWalletController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    public static PlayerWalletController Instance;
    private const string TotalCoinKey = "TotalCoin";
    public int TotalCoin;

    private void Awake()
    {
        SetSingleTon();
        LoadCoin();
    }

    private void SetSingleTon() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCoin(int amount) 
    {
        TotalCoin += amount;
        UpdateCoinUI(TotalCoin);
        SaveCoin();
    }

    private void SaveCoin()
    {
        PlayerPrefs.SetInt(TotalCoinKey, TotalCoin);
        PlayerPrefs.Save();
    }

    private void LoadCoin()
    {
        TotalCoin = PlayerPrefs.GetInt(TotalCoinKey, 0);
        UpdateCoinUI(TotalCoin);
    }

    private void UpdateCoinUI(int amount) 
    {
        coinText.text = amount.ToString();
    }
}
