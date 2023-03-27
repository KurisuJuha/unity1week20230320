using UnityEngine;
using JuhaKurisu.PopoTools.InventorySystem;
using JuhaKurisu.PopoTools.Utility;

public class InventoryManager : Singleton<InventoryManager>
{
    public readonly InventorySettings<Item> inventorySettings = new(item => Settings.itemContentsList[(int)item.id].maxAmount, () => new Item());
    public Inventory<Item> inventory => _inventory;
    public Grid<Item> playerCursorGrid => _playerCursorGrid;
    [SerializeField] private Inventory<Item> _inventory;
    [SerializeField] private Grid<Item> _playerCursorGrid;

    protected override void Awake()
    {
        base.Awake();
        _inventory = inventorySettings.CreateInventory(9);
        _playerCursorGrid = inventorySettings.CreateGrid(new(ItemID.MessageBottle));
    }
}
