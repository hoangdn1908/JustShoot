using System.Collections;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        PlayDeathAnimation();
        enemyController.StartCoroutine(DisableAfterDelay());
    }

    private void StopMovement() 
    {
        enemyController.enemyMovement.Stop();
    }

    private void PlayDeathAnimation() 
    {
        enemyController.animator.SetBool("isDeath", true);
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(0.35f);
        enemyController.ObjectPool.ReturnToPool(enemyController.gameObject);
    }
}
