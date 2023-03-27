using UniRx;
using System;

public class Map
{
    public IObservable<TilePosition> onTileDestroyed => _onTileDestroyed;
    private readonly Subject<TilePosition> _onTileDestroyed;
    public IObservable<TilePosition> onTileTakeDamaged => _onTileTakeDamaged;
    private readonly Subject<TilePosition> _onTileTakeDamaged;
    public IObservable<TilePosition> onTileUpdated => _onTileUpdated;
    private readonly Subject<TilePosition> _onTileUpdated;
    private Tile[,] tiles;

    public Map()
    {
        tiles = new Tile[Settings.mapSize.x, Settings.mapSize.y];
        _onTileDestroyed = new();
        _onTileTakeDamaged = new();
        _onTileUpdated = new();
    }

    public void Load()
    {
        for (int y = 0; y < Settings.mapSize.y; y++)
        {
            for (int x = 0; x < Settings.mapSize.x; x++)
            {
                tiles[x, y] = new(TileID.Empty);
            }
        }
        for (int y = 0; y < Settings.mapSize.y; y++)
        {
            for (int x = 0; x < Settings.mapSize.x; x++)
            {
                _onTileUpdated.OnNext(new(x, y));
            }
        }
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
            _onTileDestroyed.OnNext(tilePosition);

            id = TileID.Empty;
            damage = new();
        }

        // セット
        tiles[tilePosition.x, tilePosition.y] = new Tile(id, damage);

        //ダメージを受けたことの通知
        _onTileTakeDamaged.OnNext(tilePosition);

        // 更新
        _onTileUpdated.OnNext(tilePosition);

        return true;
    }
}
