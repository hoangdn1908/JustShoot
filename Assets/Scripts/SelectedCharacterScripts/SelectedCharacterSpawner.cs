using Unity.Cinemachine;
using UnityEngine;

public class SelectedCharacterSpawner : MonoBehaviour
{
    public static SelectedCharacterSpawner Instance { get; private set; }
    [SerializeField] private CharacterDatabase characterDatabase;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private CinemachineCamera cinemachineCamera;
    public Transform SpawnedCharacter { get; private set; }
    public CharacterData SelectedCharacter { get; private set; }

    private void Awake()
    {
        if(!SetSignleton()) return;
        StoreCharacterData();
    }

    private void Start()
    {
        SpawnCharacter();
    }

    private bool SetSignleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return false;
        }
        Instance = this;
        return true;
    }

    private void SpawnCharacter() 
    {
        if (SelectedCharacter == null) return;
        if (SelectedCharacter.characterPrefab == null) return;
        GameObject characterObj = Instantiate(SelectedCharacter.characterPrefab, spawnPos.position, spawnPos.rotation);
        SpawnedCharacter = characterObj.transform;
        SetCameraTarget();
    }

    public CharacterData GetCharacter() 
    {
        string selectedCharacterId = SelectedCharacterSave.GetSelectedCharacterId();
        if (string.IsNullOrEmpty(selectedCharacterId)) return null;
        if (!CharacterOwnerShipController.IsOwned(selectedCharacterId)) return null;
        CharacterData selectedCharacter = characterDatabase.GetCharacterById(selectedCharacterId);
        if (selectedCharacter == null) return null;
        return selectedCharacter;
    }

    private void StoreCharacterData() 
    {
        SelectedCharacter = GetCharacter();
    }

    private void SetCameraTarget() 
    {
        cinemachineCamera.Target.TrackingTarget = SpawnedCharacter;
    }
}
