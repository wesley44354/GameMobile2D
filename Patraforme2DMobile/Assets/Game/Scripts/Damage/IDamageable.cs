using System;

public interface IDamageable
{
    bool dead { get;}

    void TakeDamage(int damageable);
    event Action DamageEvent;
    event Action TookDamageEvent;
}
