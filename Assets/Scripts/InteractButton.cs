using System;
using UnityEngine;
using UniRx;
using AnnulusGames.LucidTools.InputSystem;

public class InteractButton : MonoBehaviour
{
    public IObservable<Unit> onInteract => _onInteract;
    private Subject<Unit> _onInteract = new();

    private void Update()
    {
        if (LucidInput.GetKeyDown(Key.F)) _onInteract.OnNext(Unit.Default);
    }
}
