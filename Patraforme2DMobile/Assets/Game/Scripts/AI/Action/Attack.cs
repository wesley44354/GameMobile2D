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


    [InParam("TimeToCheer")]
    private float timeToCheer = 1f;


    public override TaskStatus OnUpdate()
    {
        aiController.StartCoroutine(PerformAttack());
        return TaskStatus.RUNNING;
    }


    private IEnumerator PerformAttack()
    {
        aiController.weapon.gameObject.SetActive(true);
        aiController.IsAttacking = true;
        yield return new WaitForSeconds(timeToCheer);
        aiController.IsAttacking = false;
        aiController.weapon.gameObject.SetActive(false);
    }
}