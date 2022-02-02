using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(IDamageable))]
public class PlayerController : MonoBehaviour, ICombo
{

    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;
    CharacterFacing2D playerFacing2D;
    IDamageable damageable;
    public IWeapon weapon;

    public int numeroCombo { get; private set; }

    public float tempoCombo { get; private set; }

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
        damageable = GetComponent<IDamageable>();
        weapon = GetComponentInChildren<IWeapon>(true);

        damageable.DamageEvent += OnDamage;
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


        tempoCombo = tempoCombo + Time.deltaTime;
        if (weapon != null && playerInput.IsAttackButtonDown() && tempoCombo > 0.5f)
        {
            numeroCombo++;
            if (numeroCombo > 2)
            {
                numeroCombo = 1;
            }

            tempoCombo = 0;
            weapon.Attack();
        }
        if (tempoCombo >= 1)
        {
            numeroCombo = 0;
        }
    }

    private void FixedUpdate()
    {
        float targetOffsetX = playerFacing2D.IsFacing(cameraTargetOffsetX);
        float currentOffsetX = Mathf.Lerp(cameraTarget.localPosition.x, targetOffsetX, Time.fixedDeltaTime * cameraTargetFlipSpeed);

        currentOffsetX += playerMovement.CurrentVelocity.x * Time.fixedDeltaTime * characterSpeedInfluence;

        cameraTarget.localPosition = new Vector3(currentOffsetX, cameraTarget.localPosition.y, cameraTarget.localPosition.z);
    }


    private void OnDamage()
    {
        // Morrer assim que a gente tomar qualquer dano
        playerMovement.StopImmediately();
        enabled = false;
    }

    private void OnDestroy()
    {
        if(damageable != null)
        {
            damageable.DamageEvent -= OnDamage;
        }
    }
}
