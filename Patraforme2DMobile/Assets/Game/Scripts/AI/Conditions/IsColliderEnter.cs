using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("Game/Perception/IsColliderEnter")]
public class IsColliderEnter : GOCondition
{

    [InParam("CheckTargetOnTrigger")]
    private CheckTargetOnTrigger checkTargetOnTrigger;

    public override bool Check()
    {
        return checkTargetOnTrigger.onCollisionEnter2D;
    }

}
