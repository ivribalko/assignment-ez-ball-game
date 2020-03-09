using System;
using UniRx;
using UnityEngine;

namespace EZBall.Game
{
    internal class Input
    {
        /// <summary>
        /// Emit mousePosition while screen is touched. 
        /// </summary>
        internal IObservable<Vector3> OnTouch => Observable
            .EveryUpdate()
            .SkipWhile(_ => !UnityEngine.Input.GetMouseButtonDown(0))
            .TakeWhile(_ => !UnityEngine.Input.GetMouseButtonUp(0))
            .Select(_ => UnityEngine.Input.mousePosition)
            .Repeat();

        /// <summary>
        /// Emit when back is pressed. 
        /// </summary>
        internal IObservable<Unit> OnBack => Observable
            .EveryUpdate()
            .Select(_ => UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            .Where(pressed => pressed)
            .AsUnitObservable();
    }
}