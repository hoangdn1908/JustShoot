using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        PlayIdleAnimation();
    }

    public override void LogicUpdate()
    {
        CheckDeathState();
    }

    public override void HandleInput()
    {
        ChecMoveInput();
    }

    private void StopMovement() 
    {
        playerController.playerMovement.Stop();
    }

    private void PlayIdleAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Idle);
    }

    private void ChecMoveInput() 
    {
        if (playerController.playerInput.HasMoveInput()) 
        {
            playerStateMachine.ChangeState(playerController.playerWalkState);
        }
    }

    private void CheckDeathState() 
    {
        if (!playerController.playerHealth.IsAlive()) 
        {
            playerStateMachine.ChangeState(playerController.playerDeathState);
        }
    }
}
