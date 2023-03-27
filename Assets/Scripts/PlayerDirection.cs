using UnityEngine;
using AnnulusGames.LucidTools.Inspector;
using AnnulusGames.LucidTools.InputSystem;

[HideMonoScript]
public class PlayerDirection : MonoBehaviour
{
    [SerializeField, ReadOnly, LabelText("Direction")] private Direction directionView;
    public Direction direction { get; private set; }

    private void Update()
    {
        Vector2Int inputVector = new Vector2Int((int)LucidInput.GetAxisRaw(Axis.Horizontal), (int)LucidInput.GetAxisRaw(Axis.Vertical));

        if (inputVector.x > 0) direction = Direction.Right;
        if (inputVector.x < 0) direction = Direction.Left;
        if (inputVector.y > 0) direction = Direction.Up;
        if (inputVector.y < 0) direction = Direction.Down;
        directionView = direction;
    }
}
