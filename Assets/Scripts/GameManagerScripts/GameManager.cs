using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates currentState { get; private set; }

    private void Awake()
    {
        SetSingleTon();
    }

    private void Update()
    {
        HandlePauseInput();
    }
    private void SetSingleTon()
    {
        Instance = this;
    }

    public void ChangeGameState(GameStates state)
    {
        currentState = state;
        switch (currentState)
        {
            case GameStates.Playing:
                EnterPlayingState();
                break;
            case GameStates.Pause:
                EnterPauseState();
                break;
        }
    }

    public void EnterPlayingState()
    {
        Time.timeScale = 1.0f;
        UiController.Instance.SetPausedPanelActive(false);
    }

    private void EnterPauseState()
    {
        Time.timeScale = 0f;
        UiController.Instance.SetPausedPanelActive(true);
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameState(GameStates.Pause);
        }
    }
}
