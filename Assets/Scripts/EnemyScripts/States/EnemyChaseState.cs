using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget() 
    {
        enemyController.enemyMovement.MoveToTarget(enemyController.EnemyData.moveSpeed);
    }
}
