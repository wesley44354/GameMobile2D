using UnityEngine;

public class CharacterFacing2D : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    private void Start()
    {  
        spriteRenderer = transform.Find("GFX").GetComponent<SpriteRenderer>();
    }


    public void UpdateFacing(Vector2 _movementInput)
    {
        if (_movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (_movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }


    public float IsFacing(float _OffsetX)
    {
        bool isFacingRight = spriteRenderer.flipX == false;
        float targetOffsetX = isFacingRight ? _OffsetX : -_OffsetX;
        return targetOffsetX;
    }

    public bool IsFacingRight()
    {
        return spriteRenderer.flipX == false;
    }


}
