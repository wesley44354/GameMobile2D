using UnityEngine;
using Platformer2D.Character;

public class PlayerAnimationController : CharacterAnimationController
{
    IDamageable damageable;


    protected override void Awake()
    {
        base.Awake();
        damageable = GetComponent<IDamageable>();
        damageable.DamageEvent += OnDamage;
    }

    protected override void Update()
    {
        base.Update();
        animator.SetBool(CharacterMovementAnimationKeys.IsDashing, characterMovement.IsDashing);
        animator.SetFloat(CharacterMovementAnimationKeys.VericalSpeed, characterMovement.CurrentVelocity.y / characterMovement.JumpSpeed);
        animator.SetBool(CharacterMovementAnimationKeys.IsGrounded, characterMovement.IsGrounded);
    }

    void OnDamage()
    {
        animator.SetTrigger(CharacterMovementAnimationKeys.Dead);
    }

    private void OnDestroy()
    {
        if(damageable != null)
        {
            damageable.DamageEvent -= OnDamage;
        }
    }

}

