using System;
using AnnulusGames.LucidTools.Inspector;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DropItem : MonoBehaviour
{
    public Guid guid { get; private set; }
    [SerializeField, Required] private InteractButton interactButton;

    private void Awake()
    {
        interactButton.onInteract.Subscribe(_ =>
        {
            Destroy(gameObject);
        });

        this.OnTriggerEnter2DAsObservable()
            .Where(hit => hit.TryGetComponent<Player>(out Player player))
            .Subscribe(_ =>
            {
                interactButton.gameObject.SetActive(true);
            });
        this.OnTriggerExit2DAsObservable()
            .Where(hit => hit.TryGetComponent<Player>(out Player player))
            .Subscribe(_ =>
            {
                interactButton.gameObject.SetActive(false);
            });
    }
}