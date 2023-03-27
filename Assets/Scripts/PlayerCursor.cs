using UnityEngine;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class PlayerCursor : MonoBehaviour
{
    [SerializeField, ReadOnly] private Vector2Int _tilePosition;
    public TilePosition tilePosition { get; private set; }
    [SerializeField, Required] private PlayerPosition playerPosition;
    [SerializeField, Required] private PlayerAnimator playerAnimator;
    [SerializeField, Required] private PlayerDirection playerDirection;

    private void Update()
    {
        Vector2Int directionVec = playerDirection.direction switch
        {
            Direction.Right => new(1, 0),
            Direction.Left => new(-1, 0),
            Direction.Up => new(0, 1),
            Direction.Down => new(0, -1),
            _ => new()
        };

        tilePosition = new(directionVec + playerPosition.tilePositionVector2Int);
    }
}
