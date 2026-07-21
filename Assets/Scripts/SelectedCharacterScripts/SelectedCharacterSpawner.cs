using UnityEngine;

public class SelectedCharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterDatabase characterDatabase;
    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter() 
    {
        string selectedCharacterId = SelectedCharacterSave.GetSelectedCharacterId();
        if (string.IsNullOrEmpty(selectedCharacterId)) return;
        if (!CharacterOwnerShipController.IsOwned(selectedCharacterId)) return;
        CharacterData selectedCharacter = characterDatabase.GetCharacterById(selectedCharacterId);
        if (selectedCharacter == null || selectedCharacter.characterPrefab == null) return;
        Instantiate(selectedCharacter.characterPrefab, spawnPos.position, spawnPos.rotation);
    }
}
