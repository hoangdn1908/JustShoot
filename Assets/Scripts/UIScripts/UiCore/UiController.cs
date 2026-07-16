using UnityEngine;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    [SerializeField] private GameObject pausedPanelUI;

    private void Awake()
    {
        SetSingleTon();
    }

    private void SetSingleTon() 
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SetPausedPanelActive(bool value) 
    {
        pausedPanelUI.SetActive(value);
    }
}
