using System.Collections;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        PlayDeathAnimation();
        playerController.StartCoroutine(DisableAfterDelay());
    }

    private void StopMovement() 
    {
        playerController.playerMovement.Stop();
    }

    private void PlayDeathAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Death);
    }

    private IEnumerator DisableAfterDelay() 
    {
        yield return new WaitForSeconds(0.4f);
        playerController.gameObject.SetActive(false);
    }
}
