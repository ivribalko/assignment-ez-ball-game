using System;
using UniRx;
using Zenject;

namespace EZBall.Core
{
    internal class Init : IInit, IDisposable
    {
        private readonly SignalBus signalBus;
        private readonly Subject<Unit> signal = new Subject<Unit>();

        private Init(SignalBus signalBus)
        {
            this.signalBus = signalBus;

            this.signalBus.Subscribe<InitSignal>(this.Invoke);
        }

        public void Dispose()
        {
            this.signalBus.Unsubscribe<InitSignal>(this.Invoke);

            this.signal.Dispose();
        }

        public IObservable<Unit> Done()
        {
            return this.signal;
        }

        private void Invoke()
        {
            this.signal.OnNext(default);
        }
    }
}