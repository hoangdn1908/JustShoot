using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("Information")]
    public string characterId;

    [Header("Shop")]
    public Sprite characterIconInShop;
    public int price;

    [Header("Gameplay")]
    public Sprite characterIconInGame;
    public GameObject characterPrefab;
}
