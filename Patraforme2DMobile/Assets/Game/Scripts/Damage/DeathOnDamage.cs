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


    private void Update()
    {
        Debug.Log( transform.name + lives);
    }

    public void TakeDamage(int damageable)
    {
        lives -= damageable;
        if (lives <= 0 && !dead)
        {
            DamageEvent.Invoke();
            dead = true;
        }
    }
}

