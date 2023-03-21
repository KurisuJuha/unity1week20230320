using System;
using UnityEngine;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] rightWalkAnimationSprites;
    [SerializeField] private Sprite[] leftWalkAnimationSprites;
    [SerializeField] private Sprite[] upWalkAnimationSprites;
    [SerializeField] private Sprite[] downWalkAnimationSprites;
    [SerializeField] private double animationInterval;
    [SerializeField, Required] private Rigidbody2D rb2d;
    [SerializeField, Required] private SpriteRenderer spriteRenderer;
    [SerializeField, ReadOnly] private double elapsedTime;
    [SerializeField, ReadOnly] private Direction direction = Direction.Down;

    private void Update()
    {
        elapsedTime += Time.deltaTime * rb2d.velocity.magnitude;
        Vector2Int inputVector = new Vector2Int((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));
        if (inputVector.x > 0)
        {
            spriteRenderer.sprite = rightWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % rightWalkAnimationSprites.Length];
            direction = Direction.Right;
        }
        if (inputVector.x < 0)
        {
            spriteRenderer.sprite = leftWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % leftWalkAnimationSprites.Length];
            direction = Direction.Left;
        }
        if (inputVector.y > 0)
        {
            spriteRenderer.sprite = upWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % upWalkAnimationSprites.Length];
            direction = Direction.Up;
        }
        if (inputVector.y < 0)
        {
            spriteRenderer.sprite = downWalkAnimationSprites[(int)System.Math.Floor(elapsedTime / animationInterval) % downWalkAnimationSprites.Length];
            direction = Direction.Down;
        }
        if (inputVector == Vector2Int.zero)
        {
            spriteRenderer.sprite = direction switch
            {
                Direction.Right => rightWalkAnimationSprites[0],
                Direction.Left => leftWalkAnimationSprites[0],
                Direction.Up => upWalkAnimationSprites[0],
                Direction.Down => downWalkAnimationSprites[0],
                _ => throw new Exception()
            };
        }
    }
}
