using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShopCardUI : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterPriceText;
    [SerializeField] private Button buyBtn;
    [SerializeField] private TextMeshProUGUI buyText;
    private CharacterData characterData;
    private Action<CharacterData, CharacterShopCardUI> onBuyRequested;

    public void SetUp(CharacterData data, Action<CharacterData, CharacterShopCardUI> buyCallBack, bool isOwned) 
    {
        characterData = data;
        onBuyRequested = buyCallBack;
        characterImage.sprite = data.characterIconInShop;
        characterPriceText.text = data.price.ToString();
        buyBtn.onClick.RemoveListener(OnButtonClicked);
        buyBtn.onClick.AddListener(OnButtonClicked);
        UpdateOwnedUI(isOwned);
    }

    public void SetOwned()
    {
        UpdateOwnedUI(true);
    }

    private void UpdateOwnedUI(bool isOwned)
    {
        if (isOwned)
        {
            buyText.text = "Owned";
            buyBtn.interactable = false;
        }
        else
        {
            buyText.text = "Buy";
            buyBtn.interactable = true;
        }
    }

    private void OnButtonClicked()
    {
        onBuyRequested?.Invoke(characterData, this);
    }

    private void OnDestroy()
    {
        buyBtn.onClick.RemoveListener(OnButtonClicked);
    }
}
