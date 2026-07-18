using TMPro;
using UnityEngine;

public class WalletCoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerWalletController.OnTotalCoinChanged += UpdateCoinUI;
    }

    private void Start()
    {
        UpdateCoinUI(PlayerWalletController.Instance.TotalCoin);
    }

    private void OnDisable()
    {
        PlayerWalletController.OnTotalCoinChanged -= UpdateCoinUI;
    }

    private void UpdateCoinUI(int amount)
    {
        coinText.text = amount.ToString();
    }
}
