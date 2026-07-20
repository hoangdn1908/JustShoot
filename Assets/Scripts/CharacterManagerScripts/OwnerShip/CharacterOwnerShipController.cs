using System.Collections.Generic;
using UnityEngine;

public class CharacterOwnerShipController : MonoBehaviour
{
    private const string ownedKey = "Owned_";
    private Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

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

