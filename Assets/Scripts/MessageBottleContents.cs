using System;
using UnityEngine;

[Serializable]
public class MessageBottleContents
{
    public string name => _name;
    public Vector2 position => _position;
    public string text => _text;

    [SerializeField] private string _name;
    [SerializeField] private Vector2 _position;
    [SerializeField, Multiline] private string _text;
}
