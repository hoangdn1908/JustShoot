using TMPro;
using UnityEngine;

public class LevelCoinUI : MonoBehaviour
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

    private void UpdateUI(int coinCount)
    {
        coinText.text = coinCount.ToString();
    }
}
