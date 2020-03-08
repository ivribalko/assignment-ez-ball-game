using System;
using EZBall.Rife;
using EZBall.Settings;

namespace EZBall.Main
{
    /// <summary>
    /// Main menu feature facade.
    /// </summary>
    public interface IMain : IView
    {
        IObservable<IPlanet> Run();
    }
}