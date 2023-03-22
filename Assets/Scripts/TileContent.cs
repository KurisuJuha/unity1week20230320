using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class TileContents
{
    public string name => _name;
    public TileBase tileBase => _tileBase;
    public bool destructible => _destructible;
    public int durability => _durability;

    [SerializeField] private string _name;
    [SerializeField] private TileBase _tileBase;
    [SerializeField] private bool _destructible;
    [SerializeField] private int _durability;
}