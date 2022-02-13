using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] [Min(0)] private int damage = 1;

    public IDamageable damageable;
    public bool onTriggerEnter2D;



    void OnTriggerEnter2D(Collider2D collision)
    {

        damageable = collision.GetComponent<IDamageable>();
        if(damageable != null)
        {
            onTriggerEnter2D = true;
            damageable.TakeDamage(damage);
        }
        onTriggerEnter2D = false;
    }
}
