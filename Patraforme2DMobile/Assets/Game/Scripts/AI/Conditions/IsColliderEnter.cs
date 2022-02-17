using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("Game/Perception/IsColliderEnter")]
public class IsColliderEnter : GOCondition
{

    [InParam("TriggerDamage")]
    private TriggerDamage triggerDamage;

    public override bool Check()
    {
        return true;
    }

}
