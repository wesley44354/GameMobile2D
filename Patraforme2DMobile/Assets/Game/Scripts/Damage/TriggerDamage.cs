using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{

    [SerializeField] [Min(0)] private int damage = 10;
    [SerializeField] protected float attackTime = 0.2f;



    private void Awake()
    {
        //IsAttcking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Trigger ativado: " + collision.name);

        IDamageable damageable = collision.GetComponent<IDamageable>();


        if(damageable != null)
        {  
            //if (!IsAttcking)
            {
                damageable.TakeDamage(10);
                //IsAttcking = true;
                StartCoroutine(PerformAttack());
            }
            damageable.TakeDamage(10);
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(attackTime);
        //IsAttcking = false;
    }
}
