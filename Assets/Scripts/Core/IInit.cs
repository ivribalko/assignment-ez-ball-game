using System;
using UniRx;

namespace EZBall.Core
{
    public interface IInit
    {
        IObservable<Unit> Done();
    }
}