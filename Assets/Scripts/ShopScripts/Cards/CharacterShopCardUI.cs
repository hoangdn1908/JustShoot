using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopCardUI : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterPriceText;
    [SerializeField] private Button buyBtn;
    private CharacterData characterData;
    private Action<CharacterData> onBuyRequested;

    public void SetUp(CharacterData data, Action<CharacterData> buyCallBack) 
    {
        characterData = data;
        onBuyRequested = buyCallBack;
        characterImage.sprite = data.characterIconInShop;
        characterPriceText.text = data.price.ToString();
        buyBtn.onClick.RemoveListener(OnButtonClicked);
        buyBtn.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() 
    {
        onBuyRequested?.Invoke(characterData);
    }

    private void OnDestroy()
    {
        buyBtn.onClick.RemoveListener(OnButtonClicked);
    }
}
