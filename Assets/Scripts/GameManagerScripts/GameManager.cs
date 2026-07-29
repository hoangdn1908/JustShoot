using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates currentState { get; private set; }

    private void Awake()
    {
        SetSingleTon();
    }

    private void Start()
    {
        ChangeGameState(GameStates.Playing);
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += HandleGameLoseState;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= HandleGameLoseState;
    }

    private void Update()
    {
        HandlePauseInput();
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
            case GameStates.Lose:
                EnterLoseState();
                break;
        }
    }

    #region Enter game state
    public void EnterPlayingState()
    {
        Time.timeScale = 1.0f;
        UiController.Instance.SetPausedPanelActive(false);
        UiController.Instance.SetLosePanelActive(false);
    }

    private void EnterPauseState()
    {
        Time.timeScale = 0f;
        UiController.Instance.SetPausedPanelActive(true);
        UiController.Instance.SetLosePanelActive(false);
    }

    private void EnterLoseState()
    {
        TransferLevelCoinsToWallet();
        StartCoroutine(ShowLoseScreenAfterDelay());
        AudioManager.Instance.PlayGameOverSound();
    }

    private IEnumerator ShowLoseScreenAfterDelay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
        UiController.Instance.SetPausedPanelActive(false);
        UiController.Instance.SetLosePanelActive(true);
    }
    #endregion

    #region Handle game state
    private void HandlePauseInput()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;
        if (currentState == GameStates.Lose)
            return;
        GameStates nextState = currentState == GameStates.Pause ? GameStates.Playing : GameStates.Pause;
        ChangeGameState(nextState);
    }


    private void HandleGameLoseState() 
    {
        ChangeGameState(GameStates.Lose);
    }
    #endregion

    private void TransferLevelCoinsToWallet()
    {
        int earnedCoin = LevelCoinManager.Instance.CurrentLevelCoin;
        PlayerWalletController.Instance.AddCoin(earnedCoin);
    }
}
