using UnityEngine;

public static class SelectedCharacterSave 
{
    private const string SelectedCharacterKey = "SelectedCharacterId";

    public static void SetSelectedCharacter(string characterId) 
    {
        PlayerPrefs.SetString(SelectedCharacterKey, characterId);
        PlayerPrefs.Save();
    }

    public static string GetSelectedCharacterId()  
    {
        return PlayerPrefs.GetString(SelectedCharacterKey, string.Empty);
    }

    public static bool HasSelectedCharacter() 
    {
        return PlayerPrefs.HasKey(SelectedCharacterKey);
    }
}
