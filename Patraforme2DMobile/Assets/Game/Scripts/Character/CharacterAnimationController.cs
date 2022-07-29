using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;


public static class CharacterMovementAnimationKeys
{
    public const string IsDashing = "IsDashing";
    public const string HorizontalSpeed = "HorizontalSpeed";
    public const string IsGrounded = "IsGrounded";
    public const string VericalSpeed = "VerticalSpeed";
    public const string Dead = "Dead";
    public const string IsAttacking = "IsAttacking";
    public const string tookDamage = "TookDamage";
}

public static class EnemyMovemnetAnimationKeys
{
    public const string IsChasing = "IsChasing";
}

public class CharacterAnimationController : MonoBehaviour
{

    protected Animator animator;
    protected CharacterMovement2D characterMovement;
    IDamageable damageable;

    protected virtual void Awake()
    {
        animator = transform.Find("GFX").GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
        damageable = GetComponent<IDamageable>();
        damageable.DamageEvent += OnDamage;
    }


    protected virtual void Update()
    {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);
    }


    void OnDamage()
    {
        animator.SetTrigger(CharacterMovementAnimationKeys.Dead);
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DamageEvent -= OnDamage;
        }
    }

}

