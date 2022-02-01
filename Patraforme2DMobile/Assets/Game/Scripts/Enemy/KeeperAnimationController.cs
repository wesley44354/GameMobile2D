using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAnimationController : CharacterAnimationController
{

    EnemyAIController aiController;


    protected override void Awake()
    {
        base.Awake();
        aiController = GetComponent<EnemyAIController>();
    }


    protected override void Update()
    {
        base.Update();
        animator.SetBool(EnemyMovemnetAnimationKeys.IsChasing, aiController.isChasing);
    }
}
