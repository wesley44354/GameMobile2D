using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{

    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;
    CharacterFacing2D playerFacing2D;

    [Header("Camera")]
    [SerializeField] private Transform cameraTarget;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float cameraTargetOffsetX = 2.0f;
    [Range(0.5f, 50.0f)]
    [SerializeField] private float cameraTargetFlipSpeed = 2.0f;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float characterSpeedInfluence = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = transform.Find("GFX").GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        playerFacing2D = GetComponent<CharacterFacing2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Movement
        Vector2 movementInput = playerInput.GetMovementInput();
        playerMovement.ProcessMovementInput(movementInput);

        playerFacing2D.UpdateFacing(movementInput);


        //Jump
        if (playerInput.IsJumpButtonDown())
        {
            playerMovement.Jump();
        }

        if (playerInput.IsJumpButtonHeld() == false)
        {
            playerMovement.UpdateJumpAbort();
        }

        //Dash
        if (playerInput.IsDashButtonDown())
        {
            playerMovement.Dash();
        }

        if (playerInput.IsDashButonUp())
        {
            playerMovement.Undash();
        }
    }

    private void FixedUpdate()
    {
        float targetOffsetX = playerFacing2D.IsFacing(cameraTargetOffsetX);
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed);

        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
    }
}
