using UnityEngine;

public class CharacterShopUI : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    [SerializeField] private CharacterShopCardUI characterCardPrefab;
    [SerializeField] private Transform cardContainer;
    private bool hasBuiltShop;

    private void OnEnable()
    {
        if (!hasBuiltShop) 
        {
            BuildShop();
        }
    }

    private void BuildShop() 
    {
        if (characterDatabase == null || characterCardPrefab == null || cardContainer == null) return;
        foreach (CharacterData characterData in characterDatabase.characters) 
        {
            if(characterData == null) continue;
            CharacterShopCardUI newCard = Instantiate(characterCardPrefab, cardContainer);
            bool isOwned = CharacterOwnerShipController.IsOwned(characterData.characterId);
            newCard.SetUp(characterData, HandleBuyCharacter, isOwned);
        }
        hasBuiltShop = true;
    }

    private void HandleBuyCharacter(CharacterData characterData, CharacterShopCardUI selectedCard) 
    {
        if (CharacterOwnerShipController.IsOwned(characterData.characterId)) 
        {
            selectedCard.SetOwned();
            return;
        }
        if (characterData.price > 0)
        {
            bool purchaseSuccessful = PlayerWalletController.Instance.TrySpendCoin(characterData.price);
            if (!purchaseSuccessful) return;
        }
        CharacterOwnerShipController.UnlockCharacter(characterData.characterId);
        selectedCard.SetOwned();
    }
}
