using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager Instance {  get; private set; }
    public SaveData Data { get; private set; }
    private string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    private void Awake()
    {
        if (!SetSingleton()) return;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    private bool SetSingleton() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return false; 
        }
        Instance = this;
        return true;
    }

    public void Load() 
    {
        if (!File.Exists(SavePath)) 
        {
            ResetSave();
            return;
        }
        try
        {
            string json = File.ReadAllText(SavePath);
            Data = JsonUtility.FromJson<SaveData>(json) ?? new SaveData();
            Data.ownedCharacterIds ??= new List<string>();
        }
        catch (System.Exception) 
        {
            ResetSave();
        }
    }

    public void Save() 
    {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(SavePath, json);
    }

    public void ResetSave()
    {
        Data = new SaveData();
        Save();
    }
}
