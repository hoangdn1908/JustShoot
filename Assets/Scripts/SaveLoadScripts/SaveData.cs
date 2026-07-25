using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int totalCoin = 0;
    public string selectedCharacterId = "";
    public List<string> ownedCharacterIds = new List<string>();
}
