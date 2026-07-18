using UnityEngine;

public class PlayerWalletController : MonoBehaviour
{
    public static PlayerWalletController Instance;
    public int TotalCoin {  get; private set; }

    private void Awake()
    {
        SetSingleTon();
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
    }
}
