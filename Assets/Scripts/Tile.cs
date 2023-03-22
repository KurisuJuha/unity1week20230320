public class Tile
{
    public readonly TileID id;
    public readonly TileDamage damage;

    public Tile(TileID id, TileDamage damage)
    {
        this.id = id;
        this.damage = damage;
    }

    public Tile(TileID id)
    {
        this.id = id;
        this.damage = new(0);
    }
}