using System.Collections.ObjectModel;
using AnnulusGames.LucidTools.Inspector;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject
{
    [SerializeField] private TileContents[] _tileContentsList;
    public static ReadOnlyCollection<TileContents> tileContentsList => new(GameManager.Instance.settings._tileContentsList);

    [SerializeField] private Vector2Int _mapSize;
    public static Vector2Int mapSize => new(GameManager.Instance.settings._mapSize.x, GameManager.Instance.settings._mapSize.y);
}
