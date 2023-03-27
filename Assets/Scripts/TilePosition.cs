using UnityEngine;

public struct TilePosition
{
    public readonly int x;
    public readonly int y;

    public TilePosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public TilePosition(Vector2 pos)
    {
        x = Mathf.FloorToInt(pos.x);
        y = Mathf.FloorToInt(pos.y);
    }

    public TilePosition(Vector3 pos)
    {
        x = Mathf.FloorToInt(pos.x);
        if (x < 0) x = 0;
        if (x >= Settings.mapSize.x) x = Settings.mapSize.x - 1;
        y = Mathf.FloorToInt(pos.y);
        if (y < 0) y = 0;
        if (y >= Settings.mapSize.y) y = Settings.mapSize.y - 1;
    }
}