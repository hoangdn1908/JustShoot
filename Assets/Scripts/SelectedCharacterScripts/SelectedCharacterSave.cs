using UnityEngine;

public static class SelectedCharacterSave 
{

    public static void SetSelectedCharacter(string characterId)
    {
        if (GameSaveManager.Instance == null || GameSaveManager.Instance.Data == null)
            return;
        GameSaveManager.Instance.Data.selectedCharacterId = characterId ?? string.Empty;
        GameSaveManager.Instance.Save();
    }

    public static string GetSelectedCharacterId()
    {
        if (GameSaveManager.Instance == null || GameSaveManager.Instance.Data == null)
            return string.Empty;
        return GameSaveManager.Instance.Data.selectedCharacterId ?? string.Empty;
    }

    public static bool HasSelectedCharacter() 
    {
        return !string.IsNullOrEmpty(GetSelectedCharacterId());
    }
}
