using UnityEngine;
using UnityEngine.Tilemaps;
using UniRx;

public class MapManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    public Map map { get; private set; }

    private void Awake()
    {
        map = new Map();
        map.onTileUpdated
            .Subscribe(tilePosition => OnTileUpdated(tilePosition))
            .AddTo(this);
        map.onTileDestroyed
            .Subscribe(tilePosition => onTileDestroyed(tilePosition))
            .AddTo(this);
        map.onTileTakeDamaged
            .Subscribe(tilePosition => OnTileTakeDamaged(tilePosition))
            .AddTo(this);
    }

    private void Start()
    {
        map.Load();
    }

    private void OnTileUpdated(TilePosition tilePosition)
    {
        Vector3Int position = new Vector3Int(tilePosition.x, tilePosition.y, 0);
        Tile tile = map.GetTile(tilePosition);
        int id = (int)tile.id;
        TileContents tileContents = Settings.tileContentsList[id];
        tilemap.SetTile(position, tileContents.tileBase);
    }

    private void onTileDestroyed(TilePosition tilePosition)
    {

    }

    private void OnTileTakeDamaged(TilePosition tilePosition)
    {

    }
}
