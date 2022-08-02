using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IDamageable))]
public class EnemyDoorEnviroment : MonoBehaviour
{

    IDamageable damageable;
    DeathOnDamage deathOnDamage;
    Animator animator;


    [SerializeField] HealthBar healthBar;


    private void Start()
    {
        damageable = GetComponent<IDamageable>();
        animator = GetComponentInChildren<Animator>();
        deathOnDamage = GetComponent<DeathOnDamage>();

        healthBar.SetMaxHealth(deathOnDamage.Lives);
        damageable.DamageEvent += OnDamage;
        damageable.TookDamageEvent += OnTookDamage;
    }

    private void OnTookDamage()
    {
        healthBar.SetHealth(deathOnDamage.Lives);
        animator.SetTrigger(CharacterMovementAnimationKeys.tookDamage);
    }

    private void OnDamage()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DamageEvent -= OnDamage;
            damageable.TookDamageEvent -= OnTookDamage;
        }
    }
}

