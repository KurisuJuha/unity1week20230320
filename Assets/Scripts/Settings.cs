using System.Collections.ObjectModel;
using AnnulusGames.LucidTools.Inspector;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject
{
    [SerializeField, TabGroup("Tab", "Map")] private TileContents[] _tileContentsList;
    public static ReadOnlyCollection<TileContents> tileContentsList => new(GameManager.Instance.settings._tileContentsList);

    [SerializeField, TabGroup("Tab", "Map")] private Vector2Int _mapSize;
    public static Vector2Int mapSize => new(GameManager.Instance.settings._mapSize.x, GameManager.Instance.settings._mapSize.y);

    [SerializeField, TabGroup("Tab", "Item")] private ItemContents[] _itemContentsList;
    public static ReadOnlyCollection<ItemContents> itemContentsList => new(GameManager.Instance.settings._itemContentsList);

    [SerializeField, TabGroup("Tab", "MessageBottle")] private MessageBottleContents[] _messageBottleList;
    public static ReadOnlyCollection<MessageBottleContents> messageBottleList => new(GameManager.Instance.settings._messageBottleList);
}
