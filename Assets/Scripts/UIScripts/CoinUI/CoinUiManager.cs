using TMPro;
using UnityEngine;

public class CoinUiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coinCount = 0;

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDied += AddCoin;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDied -= AddCoin;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = coinCount.ToString();
    }
}
