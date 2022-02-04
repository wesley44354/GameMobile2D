using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{
    public event Action DamageEvent;
    public event Action AttackEvent;

    public void TakeDamage(int damageable)
    {
        DamageEvent.Invoke();
    }
}
