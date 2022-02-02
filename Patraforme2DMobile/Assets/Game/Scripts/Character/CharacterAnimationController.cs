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
}

public static class EnemyMovemnetAnimationKeys
{
    public const string IsChasing = "IsChasing";
}

public class CharacterAnimationController : MonoBehaviour
{

    protected Animator animator;
    protected CharacterMovement2D characterMovement;


    protected virtual void Awake()
    {
        animator = transform.Find("GFX").GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement2D>();
    }


    protected virtual void Update()
    {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, characterMovement.CurrentVelocity.x / characterMovement.MaxGroundSpeed);
    }

}

