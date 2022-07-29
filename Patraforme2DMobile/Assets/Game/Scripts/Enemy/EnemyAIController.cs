using Platformer2D.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(IDamageable))]
public class EnemyAIController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    CharacterFacing2D enemyFacing;
    IDamageable damageable;

    private bool isChasing;


    private Vector2 startPosition;

    public Vector2 StartPosition { get => startPosition; }

    public bool tookDamage { get; private set; }

    public bool onCollisionEnter2D;

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
        startPosition = new Vector2(transform.position.x, transform.position.y);
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFacing = GetComponent<CharacterFacing2D>();
        damageable = GetComponent<IDamageable>();

        damageable.DamageEvent += OnDamage;
        damageable.TookDamageEvent += OnTookDamage;
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

    private void OnTookDamage()
    {
        tookDamage = true;
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DamageEvent -= OnDamage;
            damageable.TookDamageEvent -= OnTookDamage;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && !collision.collider.isTrigger)
            onCollisionEnter2D = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !collision.collider.isTrigger)
            onCollisionEnter2D = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !collision.collider.isTrigger)
            onCollisionEnter2D = false;
    }
}