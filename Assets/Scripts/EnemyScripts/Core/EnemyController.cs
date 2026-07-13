using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(EnemyHealth))]
public class EnemyController : MonoBehaviour
{
    public EnemyData EnemyData;
    public ObjectPool ObjectPool {  get; private set; }

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

    private void UpdateStateLogic() 
    {
        enemyStateMachine.currentState.LogicUpdate();
    }

    private void UpdateStatePhysics() 
    {
        enemyStateMachine.currentState.PhysicsUpdate();
    }

    public void PrepareForSpawn(ObjectPool pool, Transform target)
    {
        StopAllCoroutines();
        ObjectPool = pool;
        enemyHealth.SetCurrentHealth();
        enemyMovement.SetTarget(target);
        animator.SetBool("isDeath", false);
        enemyStateMachine.InitializeState(enemyChaseState);
    }
}
