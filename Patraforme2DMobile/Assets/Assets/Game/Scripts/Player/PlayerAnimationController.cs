using UnityEngine;
using Platformer2D.Character;

public class PlayerAnimationController : CharacterAnimationController
{
    protected override void Update()
    {
        animator.SetBool(CharacterMovementAnimationKeys.IsDashing, playerController.IsDashing);
        animator.SetFloat(CharacterMovementAnimationKeys.VericalSpeed, playerController.CurrentVelocity.y / playerController.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, playerController.IsGrounded);
    }

}

