using UnityEngine;

public class PlayerPrefsDebug : MonoBehaviour
{
    [ContextMenu("Reset Data")]
    public void ResetPlayerPrefs()
    {
       GameSaveManager.Instance.ResetSave();
    }
}