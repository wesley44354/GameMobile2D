using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using Platformer2D.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Game/Ghost")]
public class Ghost : BasePrimitiveAction
{


    [InParam("AIController")]
    private EnemyAIController aiController;


    [InParam("ChaseSpeed")]
    private float chaseSpeed = 2;

    [InParam("CharacterMovement")]
    private CharacterMovement2D charMovement;




    public override void OnStart()
    {
        charMovement.MaxGroundSpeed = chaseSpeed;
        aiController.StartCoroutine(TEMP_Walk());
        base.OnStart();
    }



    public override void OnAbort()
    {
        base.OnAbort();

        //TODO: Remover Corotina
        aiController.StopAllCoroutines();
    }



    IEnumerator TEMP_Walk()
    {
        while (true)
        {
            aiController.MovementInput = new Vector2(-1, 0);
            yield return new WaitForSeconds(5.0f);
            aiController.gameObject.transform.position = aiController.startPosition;
            yield return new WaitForSeconds(1.0f);


        }
    }
}
