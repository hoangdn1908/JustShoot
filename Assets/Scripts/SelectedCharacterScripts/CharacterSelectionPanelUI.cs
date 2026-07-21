using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionPanelUI : MonoBehaviour
{
    [SerializeField] private CharacterDatabase characterDatabase;
    [SerializeField] private OwnedCharacterCardUI ownedCharacterCardUIPrefab;
    [SerializeField] private Transform characterContainer;
    private string gamePlayScene = "PlayingScene";
    private List<OwnedCharacterCardUI> spawnedCards = new List<OwnedCharacterCardUI>();
    private bool isLoadingScene;

    private void OnEnable() 
    {
        BuildSelectedCard();
    }

    private void BuildSelectedCard() 
    {
        ClearOldCard();
        if (characterDatabase == null || characterContainer == null || ownedCharacterCardUIPrefab == null) return;
        foreach (CharacterData characterData in characterDatabase.characters) 
        {
            if (characterData == null) continue;
            if (!CharacterOwnerShipController.IsOwned(characterData.characterId)) continue;
            OwnedCharacterCardUI newCard = Instantiate(ownedCharacterCardUIPrefab, characterContainer);
            newCard.SetUp(characterData, SelectCharacter);
            spawnedCards.Add(newCard);
        }
    }

    private void SelectCharacter(CharacterData characterData) 
    {
        if (isLoadingScene) return;
        isLoadingScene = true;
        SelectedCharacterSave.SetSelectedCharacter(characterData.characterId);
        Debug.Log("Choose " + characterData.characterId);
        SceneManager.LoadScene(gamePlayScene);
    }

    private void ClearOldCard() 
    {
        foreach (OwnedCharacterCardUI ownedCharacterCardUI in spawnedCards) 
        {
            if (ownedCharacterCardUI == null) continue;
            ownedCharacterCardUI.gameObject.SetActive(false);
            Destroy(ownedCharacterCardUI.gameObject);
        }
        spawnedCards.Clear();
    }
}
