using UnityEngine;
using UnityEngine.UI;
using UniRx;
using AnnulusGames.LucidTools.Inspector;
using JuhaKurisu.PopoTools.Extentions;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField, Required] private Button button;
    [SerializeField, Required] private Image image;
    [SerializeField] private int inventoryIndex;

    private void Awake()
    {
        button.onClick.AsObservable()
            .Subscribe(_ =>
            {
                InventoryManager.Instance.playerCursorGrid.Exchange(InventoryManager.Instance.inventory.grids[inventoryIndex]);
            })
            .AddTo(this);
    }

    private void Update()
    {
        image.sprite = Settings.itemContentsList[(int)InventoryManager.Instance.inventory.grids[inventoryIndex].item.id].sprite;
    }
}
