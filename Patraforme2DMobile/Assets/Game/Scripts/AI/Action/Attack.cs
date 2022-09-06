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
    private const string ENEMY_ATTACK = "EnemyAttack";

    [InParam("TriggerDamage")]
    private GameObject triggerDamage;

    [InParam("Weapon")]
    private GameObject weapon;


    [InParam("AIController")]
    private EnemyAIController aiController;


    [InParam("attackTime")]
    private float attackTime;

    public override void OnStart()
    {
        triggerDamage.gameObject.SetActive(false);
        weapon.gameObject.SetActive(false);
        aiController.IsAttacking = false;
        PerformAttack();
    }

    public void PerformAttack()
    {
        if (!aiController.IsAttacking)
        {
            aiController.StartCoroutine(PerformAttackCoroutine());
        }
    }


    private IEnumerator PerformAttackCoroutine()
    {
        weapon.gameObject.SetActive(true);
        aiController.IsAttacking = true;
        yield return new WaitForSeconds(attackTime);
        triggerDamage.gameObject.SetActive(true);
        AudioManager.instance.PlaySound(ENEMY_ATTACK);
        yield return new WaitForSeconds(attackTime);
        triggerDamage.gameObject.SetActive(false);
        weapon.gameObject.SetActive(false);
        aiController.IsAttacking = false;
    }
}