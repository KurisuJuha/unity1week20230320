using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu]
public class Settings : ScriptableObject
{
    [SerializeField] private TileContents[] _tileContentsList;
    public static ReadOnlyCollection<TileContents> tileContents => new(GameManager.Instance.settings._tileContentsList);
}
