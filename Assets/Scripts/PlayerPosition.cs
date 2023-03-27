using UnityEngine;
using AnnulusGames.LucidTools.Inspector;

[HideMonoScript]
public class PlayerPosition : MonoBehaviour
{
    [SerializeField, ReadOnly, LabelText("Tile Position")] public Vector2Int tilePositionVector2Int;
    public TilePosition tilePosition { get; private set; }

    private void Update()
    {
        tilePosition = new(transform.position);
        tilePositionVector2Int = new(tilePosition.x, tilePosition.y);
    }
}
