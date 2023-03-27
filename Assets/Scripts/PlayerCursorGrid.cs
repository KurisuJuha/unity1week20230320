using UnityEngine;
using UnityEngine.UI;
using AnnulusGames.LucidTools.Inspector;
using AnnulusGames.LucidTools.InputSystem;
using JuhaKurisu.PopoTools.Extentions;
using UniRx;

public class PlayerCursorGrid : MonoBehaviour
{
    [SerializeField, Required] private Image image;
    [SerializeField, Required] private RectTransform rectTransform;

    private void Awake()
    {
        // コードレビューするならなんでここが動かないのか教えてほしい
        /*
        InventoryManager.Instance.playerCursorGrid.item.ObserveEveryValueChanged(item => item)
            .Subscribe(_ =>
            {
                UpdateSprite();
                "observeEveryValueChangedTest".Inspect();
            })
            .AddTo(this);*/
    }

    private void Update()
    {
        UpdateSprite();
        rectTransform.SetPositionX(LucidInput.mousePosition.x);
        rectTransform.SetPositionY(LucidInput.mousePosition.y);
    }

    private void UpdateSprite()
    {
        Item item = InventoryManager.Instance.playerCursorGrid.item;
        image.sprite = Settings.itemContentsList[(int)item.id].sprite;
    }
}
