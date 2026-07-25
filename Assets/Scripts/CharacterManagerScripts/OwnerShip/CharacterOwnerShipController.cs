using System.Collections.Generic;
using UnityEngine;

public static class CharacterOwnerShipController 
{
    public static bool IsOwned(string characterId)
    {
        if (GameSaveManager.Instance == null || GameSaveManager.Instance.Data == null)
            return false;
        if (string.IsNullOrEmpty(characterId))
            return false;
        return GameSaveManager.Instance.Data.ownedCharacterIds.Contains(characterId);
    }

    public static void UnlockCharacter(string characterId)
    {
        if (GameSaveManager.Instance == null || GameSaveManager.Instance.Data == null)
            return;
        if (string.IsNullOrEmpty(characterId))
            return;
        var ownedIdList = GameSaveManager.Instance.Data.ownedCharacterIds;
        if (ownedIdList == null)
        {
            ownedIdList = new List<string>();
            GameSaveManager.Instance.Data.ownedCharacterIds = ownedIdList;
        }
        if (!ownedIdList.Contains(characterId))
        {
            ownedIdList.Add(characterId);
            GameSaveManager.Instance.Save();
        }
    }
}

