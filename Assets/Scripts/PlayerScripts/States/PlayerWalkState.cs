using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        PlayWalkAnimation();
    }

    public override void LogicUpdate()
    {
        CheckDeathState();
    }

    public override void PhysicUpdate()
    {
        MovePlayer();
    }

    public override void HandleInput()
    {
        CheckIdleInput();
    }

    private void PlayWalkAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Walk);
    }

    private void MovePlayer() 
    {
        playerController.playerMovement.Move(playerController.playerInput.MoveInput, playerController.playerData.moveSpeed);
    }

    private void CheckIdleInput()
    {
        if (!playerController.playerInput.HasMoveInput())
        {
            playerStateMachine.ChangeState(playerController.playerIdleState);
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
