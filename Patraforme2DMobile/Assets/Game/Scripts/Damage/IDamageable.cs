using System;

public interface IDamageable
{

    int health { get; }
    void TakeDamage(int damageable);
    event Action DamageEvent;
    event Action AttackEvent;
}
