using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Action("Game/ChaseTarget")]
public class ChaseTarget : BasePrimitiveAction
{

    [InParam("Target")]
    private Transform target;

    [InParam("AIController")]
    private EnemyAIController aiController;


    public override void OnStart()
    {
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        Vector2 toTarget = target.transform.position - aiController.transform.position;
        aiController.MovementInput = new Vector2(Mathf.Sign(toTarget.x), (Mathf.Sign(toTarget.y)));

        return TaskStatus.RUNNING;
    }
}
