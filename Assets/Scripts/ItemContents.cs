using System;
using UnityEngine;
using AnnulusGames.LucidTools.Inspector;

[Serializable]
public class ItemContents
{
    public string name => _name;
    public int maxAmount => _maxAmount;
    public Sprite sprite => _sprite;

    [SerializeField] private string _name;
    [SerializeField, Range(1, 99)] private int _maxAmount;
    [SerializeField, Required] private Sprite _sprite;
}
