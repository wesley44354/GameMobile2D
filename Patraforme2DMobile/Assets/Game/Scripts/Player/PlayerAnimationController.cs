using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(IDamageable))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(IisAttcking))]
public class PlayerAnimationController : CharacterAnimationController
{
    IisAttcking isAttcking;
    PlayerController player;

    protected override void Awake()
    {
        base.Awake();
        isAttcking = GetComponent<IisAttcking>();
    }

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
        animator.SetBool(CharacterMovementAnimationKeys.IsAttacking + player.numeroCombo, player.weapon.IsAttcking);
    }

}

