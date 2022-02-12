using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysMelleWeapon : TriggerDamage, IWeapon
{

    public bool IsAttacking { get; private set; }

    [SerializeField] protected float attackTime = 0.2f;

    private void Awake()
    {
        gameObject.SetActive(false);
        IsAttacking = false;
    }


    public void Attack()
    {
        if (!IsAttacking)
        {
            gameObject.SetActive(true);
            IsAttacking = true;
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
        IsAttacking = false;
    }
}
