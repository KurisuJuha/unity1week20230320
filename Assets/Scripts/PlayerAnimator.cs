using System;
using UnityEngine;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Sprite rightIdleSprite;
    [SerializeField] private Sprite leftIdleSprite;
    [SerializeField] private Sprite upIdleSprite;
    [SerializeField] private Sprite downIdleSprite;
    [SerializeField] private Sprite[] rightWalkAnimationSprites;
    [SerializeField] private Sprite[] leftWalkAnimationSprites;
    [SerializeField] private Sprite[] upWalkAnimationSprites;
    [SerializeField] private Sprite[] downWalkAnimationSprites;
    [SerializeField] private double animationInterval;
    [SerializeField, Required] private Rigidbody2D rb2d;
    [SerializeField, Required] private SpriteRenderer spriteRenderer;
    [SerializeField, Required] private PlayerDirection playerDirection;
    [SerializeField, ReadOnly] private double elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime * rb2d.velocity.magnitude;
        Vector2Int inputVector = new Vector2Int((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));
        if (inputVector.x > 0)
        {
            spriteRenderer.sprite = rightWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % rightWalkAnimationSprites.Length];
        }
        if (inputVector.x < 0)
        {
            spriteRenderer.sprite = leftWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % leftWalkAnimationSprites.Length];
        }
        if (inputVector.y > 0)
        {
            spriteRenderer.sprite = upWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % upWalkAnimationSprites.Length];
        }
        if (inputVector.y < 0)
        {
            spriteRenderer.sprite = downWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % downWalkAnimationSprites.Length];
        }
        if (inputVector == Vector2Int.zero)
        {
            spriteRenderer.sprite = playerDirection.direction switch
            {
                Direction.Right => rightIdleSprite,
                Direction.Left => leftIdleSprite,
                Direction.Up => upIdleSprite,
                Direction.Down => downIdleSprite,
                _ => throw new Exception()
            };
        }
    }
}
