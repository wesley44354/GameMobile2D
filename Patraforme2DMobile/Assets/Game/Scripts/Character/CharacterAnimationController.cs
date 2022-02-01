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
}

public class CharacterAnimationController : MonoBehaviour
{

    protected Animator animator;
    protected CharacterMovement2D playerController;


    protected virtual void Awake()
    {
        animator = transform.Find("GFX").GetComponent<Animator>();
        playerController = GetComponent<CharacterMovement2D>();
    }


    protected virtual void Update()
    {
        animator.SetFloat(CharacterMovementAnimationKeys.HorizontalSpeed, playerController.CurrentVelocity.x / playerController.MaxGroundSpeed);
    }

}

