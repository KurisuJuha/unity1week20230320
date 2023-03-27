using UnityEngine;
using System;

[Serializable]
public class Item
{
    public ItemID id => _id;
    [SerializeField] private ItemID _id;

    public Item(ItemID id = ItemID.Empty)
    {
        this._id = id;
    }

    public override bool Equals(object obj)
    {
        ItemID otherItemID = ((Item)obj).id;
        return id == otherItemID;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
