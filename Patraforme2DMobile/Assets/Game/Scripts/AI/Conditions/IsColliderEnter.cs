using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("Game/Perception/IsColliderEnter")]
public class IsColliderEnter : GOCondition
{

    [InParam("EnemyAiController")]
    private EnemyAIController enemyAIController;

    public override bool Check()
    {
        return enemyAIController.onCollisionEnter2D;
    }

}
