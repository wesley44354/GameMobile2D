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
    [InParam("AIController")]
    private EnemyAIController aiController;

    [InParam("TriggerDamage")]
    private TriggerDamage triggerDamage;

    [InParam("TimeToCheer")]
    private float timeToCheer = 1f;

    public override void OnStart()
    {
        base.OnStart();
        aiController.IsAttacking = false;

    }

    public override TaskStatus OnUpdate()
    {
        aiController.StartCoroutine(PerformAttack());
        return TaskStatus.RUNNING;
    }


    private IEnumerator PerformAttack()
    {
        if (triggerDamage.onTriggerEnter2D && !aiController.IsAttacking)
        {
            aiController.IsAttacking = true;
            yield return new WaitForSeconds(timeToCheer);
            aiController.IsAttacking = false;
        }
    }
}