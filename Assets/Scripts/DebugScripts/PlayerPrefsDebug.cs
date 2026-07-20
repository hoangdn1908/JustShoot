using UnityEngine;

public class PlayerPrefsDebug : MonoBehaviour
{
    [ContextMenu("Reset PlayerPrefs")]
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs has been reset.");
    }
}