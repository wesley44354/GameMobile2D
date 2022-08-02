using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private int lives;

    public int Lives { get => lives; }

    public bool dead { get; private set; }

    public event Action DamageEvent;
    public event Action TookDamageEvent;


    public void TakeDamage(int damageable)
    {
        lives -= damageable;
        TookDamageEvent.Invoke();   
        if (lives <= 0 && !dead)
        {
            DamageEvent.Invoke();
            dead = true;
        }
    }
}

