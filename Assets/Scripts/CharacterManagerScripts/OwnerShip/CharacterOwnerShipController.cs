using UnityEngine;

public static class CharacterOwnerShipController 
{
    private const string ownedKey = "Owned_";

    public static bool IsOwned(string characterId) 
    {
        string key = ownedKey + characterId;
        return PlayerPrefs.GetInt(key, 0) == 1;
    }

    public static void UnlockCharacter(string characterId) 
    {
        string key = ownedKey + characterId;
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }
}

