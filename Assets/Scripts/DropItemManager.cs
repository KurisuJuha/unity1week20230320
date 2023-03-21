using System;
using UnityEngine;
using System.Collections.Generic;
using JuhaKurisu.PopoTools.Utility;
using AnnulusGames.LucidTools.Inspector;

public class DropItemManager : Singleton<DropItemManager>
{
    private Dictionary<Guid, DropItem> dropItems;
    [SerializeField] private DropItem dropItemPrefab;

    private void Start()
    {
        dropItems = new();
    }

    [Button]
    public DropItem CreateDropItem() => CreateDropItem(Vector2.zero, 0);

    public DropItem CreateDropItem(Vector2 position, float rotation)
    {
        DropItem newDropItem = GameObject.Instantiate(dropItemPrefab, (Vector3)position, Quaternion.Euler(0, 0, rotation));
        dropItems[newDropItem.guid] = newDropItem;
        return newDropItem;
    }
}