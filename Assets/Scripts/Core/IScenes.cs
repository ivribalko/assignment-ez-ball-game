using System;
using UniRx;

namespace EZBall.Core
{
    public interface IScenes
    {
        IObservable<Unit> Add(Scene scene);
        IObservable<Unit> Load(Scene scene);
        IObservable<Unit> Unload(Scene scene);
    }
}