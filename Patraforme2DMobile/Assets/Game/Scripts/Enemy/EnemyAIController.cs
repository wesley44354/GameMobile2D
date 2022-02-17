using Platformer2D.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(IDamageable))]
public class EnemyAIController : MonoBehaviour
{

    public GameObject weapon;

    CharacterMovement2D enemyMovement;
    CharacterFacing2D enemyFacing;
    IDamageable damageable;

    private bool isChasing;
    public bool IsChasing
    {
        get => isChasing;
        set => isChasing = value;
    }

    private bool isAttacking;

    public bool IsAttacking
    {
        get => isAttacking;
        set => isAttacking = value;
    }


    Vector2 movementInput;
    public Vector2 MovementInput
    {
        get => movementInput;
        set => movementInput = new Vector2(Mathf.Clamp(value.x, -1, 1), Mathf.Clamp(value.y, -1, 1));
    }



    private void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFacing = GetComponent<CharacterFacing2D>();
        damageable = GetComponent<IDamageable>();

        damageable.DamageEvent += OnDamage;
    }


    private void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFacing.UpdateFacing(movementInput);
    }

    private void OnDamage()
    {
        enemyMovement.StopImmediately();
    }


    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DamageEvent -= OnDamage;
        }
    }

}