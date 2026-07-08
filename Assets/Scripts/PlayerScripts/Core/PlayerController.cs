using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;

    #region Component
    public PlayerInput playerInput {  get; private set; }
    public PlayerMovement playerMovement { get; private set; }
    public PlayerAnimation playerAnimation { get; private set; }
    #endregion

    #region State Machine
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState playerIdleState { get; private set; }
    public PlayerWalkState playerWalkState { get; private set; }
    #endregion

    private void Awake()
    {
        InitializeComponent();
        InitializeState();
    }

    private void Start()
    {
        InitializeIdleState();
    }

    private void Update()
    {
        UpdateStateLogic();
        HandleInput();
    }

    private void FixedUpdate()
    {
        UpdateStatePhysic();
    }

    private void InitializeComponent() 
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void InitializeState() 
    {
        playerStateMachine = new PlayerStateMachine();
        playerIdleState = new PlayerIdleState(this, playerStateMachine);
        playerWalkState = new PlayerWalkState(this, playerStateMachine);
    }

    private void InitializeIdleState() 
    {
        playerStateMachine.InitializeState(playerIdleState);
    }

    private void UpdateStateLogic() 
    {
        playerStateMachine.currentState.LogicUpdate();
    }

    private void HandleInput() 
    {
        playerStateMachine.currentState.HandleInput();
        playerInput.ReadInput();
    }

    private void UpdateStatePhysic() 
    {
        playerStateMachine.currentState.PhysicUpdate();
    }
}
