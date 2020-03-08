using System;
using UniRx;
using UnityEngine;

namespace EZBall.Game
{
    internal class Input
    {
        internal IObservable<Unit> OnBack()
        {
            return Observable
                .EveryUpdate()
                .Select(_ => UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                .Where(pressed => pressed)
                .AsUnitObservable();
        }
    }
}