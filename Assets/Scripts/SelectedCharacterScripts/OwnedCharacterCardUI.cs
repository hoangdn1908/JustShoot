using System;
using UnityEngine;
using UnityEngine.UI;

public class OwnedCharacterCardUI : MonoBehaviour
{
    [SerializeField] private Image characterIcon;
    [SerializeField] private Button selectBtn;
    private CharacterData characterData;
    private Action<CharacterData> onCharacterSelected;

    public void SetUp(CharacterData data, Action<CharacterData> selectCallBack) 
    {
        characterData = data;
        onCharacterSelected = selectCallBack;
        characterIcon.sprite = data.characterIconInShop;
        selectBtn.onClick.RemoveListener(SelectCharacter);
        selectBtn.onClick.AddListener(SelectCharacter);
    }

    private void SelectCharacter() 
    {
        onCharacterSelected?.Invoke(characterData);
    }

    private void OnDestroy()
    {
        selectBtn.onClick.RemoveListener(SelectCharacter);
    }
}
