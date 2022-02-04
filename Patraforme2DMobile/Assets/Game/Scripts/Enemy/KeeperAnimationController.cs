using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAnimationController : CharacterAnimationController
{

    EnemyAIController aiController;
    [SerializeField] private TriggerDamage triggerDamage;


    protected override void Awake()
    {
        base.Awake();
        aiController = GetComponent<EnemyAIController>();
    }



    protected override void Update()
    {
        base.Update();
        animator.SetBool(EnemyMovemnetAnimationKeys.IsChasing, aiController.IsChasing);
        animator.SetBool(CharacterMovementAnimationKeys.IsAttacking, aiController.IsAttacking);
    }
}
