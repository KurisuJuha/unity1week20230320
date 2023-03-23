using UniRx;

public class Map
{
    public readonly Subject<TilePosition> onTileDestroyed;
    public readonly Subject<TilePosition> onTileTakeDamaged;
    public readonly Subject<TilePosition> onTileUpdated;
    private Tile[,] tiles;

    public Map()
    {
        tiles = new Tile[10, 10];
        onTileDestroyed = new();
        onTileTakeDamaged = new();
        onTileUpdated = new();
    }

    public Tile GetTile(TilePosition tilePosition)
    {
        return tiles[tilePosition.x, tilePosition.y];
    }

    public bool TryAddDamage(int power, TilePosition tilePosition)
    {
        Tile tile = tiles[tilePosition.x, tilePosition.y];

        // 破壊不可能の場合はそもそも破壊しない
        if (!Settings.tileContentsList[(int)tile.id].destructible) return false;

        TileID id = tile.id;
        TileDamage damage = new(tile.damage.value + power);

        // ダメージが許容値を超えた場合破壊する
        if (Settings.tileContentsList[(int)id].durability <= damage.value)
        {
            // 破壊されたことの通知
            onTileDestroyed.OnNext(tilePosition);

            id = TileID.Empty;
            damage = new();
        }

        // セット
        tiles[tilePosition.x, tilePosition.y] = new Tile(id, damage);

        //ダメージを受けたことの通知
        onTileTakeDamaged.OnNext(tilePosition);

        // 更新
        onTileUpdated.OnNext(tilePosition);

        return true;
    }
}
