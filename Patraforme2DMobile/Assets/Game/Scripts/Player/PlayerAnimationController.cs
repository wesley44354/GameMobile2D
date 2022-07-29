using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(IDamageable))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(IisAttcking))]
public class PlayerAnimationController : CharacterAnimationController
{
    PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    protected override void Update()
    {
        base.Update();
        animator.SetBool(CharacterMovementAnimationKeys.IsDashing, characterMovement.IsDashing);
        animator.SetFloat(CharacterMovementAnimationKeys.VericalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, characterMovement.IsGrounded);
        if(player.numeroCombo == 1 || player.numeroCombo == 2)
            animator.SetBool(CharacterMovementAnimationKeys.IsAttacking + player.numeroCombo, player.weapon.IsAttacking); 
    }

}

