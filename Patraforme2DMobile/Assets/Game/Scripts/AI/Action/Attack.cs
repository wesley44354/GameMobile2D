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


    [InParam("AIController")]
    private EnemyAIController aiController;


    [InParam("TimeToCheer")]
    private float timeToCheer = 1f;

    public override void OnStart()
    {
        aiController.StartCoroutine(PerformAttack());
        base.OnStart();
    }


    public override TaskStatus OnUpdate()
    {
        return TaskStatus.RUNNING;
    }


    private IEnumerator PerformAttack()
    {
        aiController.IsAttacking = true;
        yield return new WaitForSeconds(timeToCheer);
        AudioManager.instance.PlaySound(ENEMY_ATTACK);
        aiController.IsAttacking = false;
    }
}