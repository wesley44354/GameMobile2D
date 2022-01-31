using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("Game/ChaseTarget")]
public class ChaseTarget : BasePrimitiveAction
{



    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("ChaseTarget: OnStart");
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("ChaseTarget: OnUpdate");

        return TaskStatus.RUNNING;
    }
}
