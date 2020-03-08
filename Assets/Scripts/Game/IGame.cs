using System;
using EZBall.Settings;
using UniRx;

namespace EZBall.Game
{
    /// <summary>
    /// Game feature facade.
    /// </summary>
    public interface IGame
    {
        IObservable<Unit> Run(IPlanet planet);
    }
}