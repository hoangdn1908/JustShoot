using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(EnemyHealth))]
public class EnemyController : MonoBehaviour
{
    public EnemyData EnemyData;

    #region Component
    public EnemyMovement enemyMovement {  get; private set; }
    public Animator animator { get; private set; }
    public EnemyHealth enemyHealth { get; private set; }
    #endregion

    #region State machine
    public EnemyStateMachine enemyStateMachine { get; private set; }
    public EnemyChaseState enemyChaseState { get; private set; }
    public EnemyDeathState enemyDeathState { get; private set; }
    #endregion

    private void Awake()
    {
        InitializeComponent();
        InitializeStateMachine();
    }

    private void Start()
    {
        InitializeState();   
    }

    private void Update()
    {
        UpdateStateLogic();
    }

    private void FixedUpdate()
    {
        UpdateStatePhysics();
    }

    private void InitializeComponent() 
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void InitializeStateMachine() 
    {
        enemyStateMachine = new EnemyStateMachine();
        enemyChaseState = new EnemyChaseState(this, enemyStateMachine);
        enemyDeathState = new EnemyDeathState(this, enemyStateMachine);
    }

    private void InitializeState() 
    {
        enemyStateMachine.InitializeState(enemyChaseState);
    }

    private void UpdateStateLogic() 
    {
        enemyStateMachine.currentState.LogicUpdate();
    }

    private void UpdateStatePhysics() 
    {
        enemyStateMachine.currentState.PhysicsUpdate();
    }
}
