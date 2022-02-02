using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{

    private struct PlayerInputConstants
    {
        public const string Horizontal = "Horizontal";
        public const string Jump = "Jump";
        public const string Dash = "Dash";
        public const string Attack = "Attack";
    }

    public Vector2 GetMovementInput()
    {
        float horizotalSpeed = Input.GetAxisRaw(PlayerInputConstants.Horizontal);

        if (Mathf.Approximately(horizotalSpeed, 0.0f))
        {
            horizotalSpeed = CrossPlatformInputManager.GetAxisRaw(PlayerInputConstants.Horizontal);
        }
        return new Vector2(horizotalSpeed, 0);
    }

    public bool IsJumpButtonDown()
    {
        bool IsKeyboardButtonDown = Input.GetButtonDown(PlayerInputConstants.Jump);
        bool IsMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Jump);
        return IsKeyboardButtonDown || IsMobileButtonDown;
    }

    public bool IsJumpButtonHeld()
    {
        bool IsJumpKeyboardButtonHeld = Input.GetButton(PlayerInputConstants.Jump);
        bool IsJumpMobileButtonHeld = CrossPlatformInputManager.GetButton(PlayerInputConstants.Jump);
        return IsJumpKeyboardButtonHeld || IsJumpMobileButtonHeld;
    }


    public bool IsDashButtonDown()
    {
        bool IsDashKeyboardButtonDown = Input.GetButtonDown(PlayerInputConstants.Dash);
        bool IsDashMobileButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Dash);
        return IsDashKeyboardButtonDown || IsDashMobileButtonDown;
    }

    public bool IsDashButonUp()
    {
        bool IsDashKeyboardButtonUp = Input.GetButton(PlayerInputConstants.Dash) == false;
        bool IsDashMobileButtonUp = CrossPlatformInputManager.GetButton(PlayerInputConstants.Dash) == false;
        return IsDashKeyboardButtonUp && IsDashMobileButtonUp;
    }

    public bool IsAttackButtonDown()
    {
        bool IsAttackKeyboardButtonDown = Input.GetButtonDown(PlayerInputConstants.Attack);
        bool IsMobileKeyboardButtonDown = CrossPlatformInputManager.GetButtonDown(PlayerInputConstants.Attack);
        return IsAttackKeyboardButtonDown || IsMobileKeyboardButtonDown;
    }
}
