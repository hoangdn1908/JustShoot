using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Scriptable Objects/CharacterDatabase")]
public class CharacterDatabase : ScriptableObject
{
    public List<CharacterData> characters;

    public CharacterData GetCharacterById(string characterId)
    {
        return characters.Find(character => character.characterId == characterId);
    }
}