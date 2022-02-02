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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_movementInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    public float IsFacing(float _OffsetX)
    {
        bool isFacingRight = transform.rotation == Quaternion.Euler(0, 0, 0);
        float targetOffsetX = isFacingRight ? _OffsetX : -_OffsetX;
        return targetOffsetX;
    }

    public bool IsFacingRight()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 0))
            return true;

        return false;
    }



}
