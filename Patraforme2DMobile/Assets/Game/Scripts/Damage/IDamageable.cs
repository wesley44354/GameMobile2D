using System;

public interface IDamageable
{
    void TakeDamage(int damageable);
    event Action DamageEvent;
    event Action AttackEvent;
}
