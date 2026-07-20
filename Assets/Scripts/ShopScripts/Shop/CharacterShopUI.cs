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
            newCard.SetUp(characterData, HandleBuyCharacter);
        }
        hasBuiltShop = true;
    }

    private void HandleBuyCharacter(CharacterData characterData) 
    {
    
    }
}
