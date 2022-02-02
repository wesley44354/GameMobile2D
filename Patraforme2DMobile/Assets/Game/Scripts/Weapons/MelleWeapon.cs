using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleWeapon : TriggerDamage, IWeapon
{


    public  bool IsAttcking { get; private set; }

    private void Awake()
    {
        gameObject.SetActive(false);
        IsAttcking = false;
    }


    public void Attack()
    {
        if (!IsAttcking)
        {
            gameObject.SetActive(true);
            IsAttcking = true;
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
        IsAttcking = false;
    }
}
