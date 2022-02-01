using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{

    [InParam("Target")]
    private Transform target;


    public override bool Check()
    {
        return (Vector3.Distance(gameObject.transform.position, target.position) < 3);
    }
}
