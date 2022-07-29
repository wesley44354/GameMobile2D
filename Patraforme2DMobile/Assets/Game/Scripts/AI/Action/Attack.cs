using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/Attack")]
public class Attack : BasePrimitiveAction
{


    [InParam("Weapon")]
    private GameObject weapon;


    [InParam("AIController")]
    private EnemyAIController aiController;


    [InParam("attackTime")]
    private float attackTime = 1f;

    public override void OnStart()
    {
        weapon.gameObject.SetActive(false);
        aiController.IsAttacking = false;
        PerformAttack();
    }

    public void PerformAttack()
    {
        if (!aiController.IsAttacking)
        {
            weapon.gameObject.SetActive(true);
            aiController.IsAttacking = true;
            weapon.GetComponentInParent<EnemyAIController>().StartCoroutine(PerformAttackCoroutine());
        }
    }


    private IEnumerator PerformAttackCoroutine()
    {
        yield return new WaitForSeconds(attackTime);
        weapon.gameObject.SetActive(false);
        aiController.IsAttacking = false;
    }
}