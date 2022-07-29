using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IDamageable))]
public class DeathOnDamageInEnviroment : MonoBehaviour
{

    IDamageable damageable;
    Animator animator;


    private void Start()
    {
        damageable = GetComponent<IDamageable>();
        animator = GetComponent<Animator>();

        damageable.DamageEvent += OnDamage;
        damageable.TookDamageEvent += OnTookDamage;
    }

    private void OnTookDamage()
    {
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

