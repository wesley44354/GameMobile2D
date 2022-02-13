using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private int lives;

    public int Lives { get => lives; }

    public event Action DamageEvent;


    public void TakeDamage(int damageable)
    {
        lives -= damageable;
        if(lives <= 0)
            DamageEvent.Invoke();
    }
}

