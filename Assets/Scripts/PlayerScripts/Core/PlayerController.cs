using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerInput), typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;

    #region Component
    public PlayerInput playerInput {  get; private set; }
    public PlayerMovement playerMovement { get; private set; }
    public PlayerAnimation playerAnimation { get; private set; }
    public PlayerHealth playerHealth { get; private set; }
    #endregion

    #region State Machine
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerIdleState playerIdleState { get; private set; }
    public PlayerWalkState playerWalkState { get; private set; }
    public PlayerDeathState playerDeathState { get; private set; }
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
        HandleInput();
        UpdateStateLogic();
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
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void InitializeState() 
    {
        playerStateMachine = new PlayerStateMachine();
        playerIdleState = new PlayerIdleState(this, playerStateMachine);
        playerWalkState = new PlayerWalkState(this, playerStateMachine);
        playerDeathState = new PlayerDeathState(this, playerStateMachine);
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
        playerInput.ReadInput();
        playerStateMachine.currentState.HandleInput();
    }

    private void UpdateStatePhysic() 
    {
        playerStateMachine.currentState.PhysicUpdate();
    }
}
