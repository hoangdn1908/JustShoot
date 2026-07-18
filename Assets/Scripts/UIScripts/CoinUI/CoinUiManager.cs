using System;
using TMPro;
using UnityEngine;

public class CoinUiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private void OnEnable()
    {
        LevelCoinManager.OnLevelCoinChanged += UpdateUI;
    }

    private void Start()
    {
        UpdateUI(LevelCoinManager.Instance.CurrentLevelCoin);
    }

    private void OnDisable()
    {
        LevelCoinManager.OnLevelCoinChanged -= UpdateUI;
    }

    public void UpdateUI(int coinCount)
    {
        coinText.text = coinCount.ToString();
    }

}
