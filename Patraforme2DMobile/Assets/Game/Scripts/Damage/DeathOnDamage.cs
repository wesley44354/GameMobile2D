using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{
    public int health { get; private set; }

    public event Action DamageEvent;
    public event Action AttackEvent;


    private void Awake()
    {
        health = 100;
    }

    public void TakeDamage(int damageable)
    {
        health -= damageable;
        if(health < 0)
            DamageEvent.Invoke();
    }

    private void Update()
    {
        Debug.Log(health);
    }
}

