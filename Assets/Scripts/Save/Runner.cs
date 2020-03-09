using System;
using EZBall.Rife;
using Zenject;

namespace EZBall.Save
{
    internal class Runner : IDisposable
    {
        private readonly Storage storage;
        private readonly SignalBus signalBus;

        private Runner(
            Storage storage,
            SignalBus signalBus)
        {
            this.storage = storage;
            this.signalBus = signalBus;

            this.signalBus.Subscribe<HitSignal>(this.Increment);
        }

        public void Dispose()
        {
            this.signalBus.Unsubscribe<HitSignal>(this.Increment);
        }

        private void Increment()
        {
            var increment = storage.Load(Keys.Hits) + 1;

            storage.Save(Keys.Hits, increment);
        }
    }
}