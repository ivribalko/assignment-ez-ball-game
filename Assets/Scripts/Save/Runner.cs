using System;
using EZBall.Rife;
using UniRx;
using Zenject;

namespace EZBall.Save
{
    internal class Runner : IDisposable
    {
        private readonly Storage storage;
        private readonly SignalBus signalBus;

        private readonly CompositeDisposable subscriptions = new CompositeDisposable();

        private Runner(
            View view,
            Storage storage,
            SignalBus signalBus)
        {
            this.storage = storage;
            this.signalBus = signalBus;

            this.signalBus.Subscribe<HitSignal>(this.Increment);

            this.storage
                .OnSaved
                .Where(pair => pair.key == Keys.Hits)
                .Select(pair => pair.value)
                .StartWith(this.storage.Load(Keys.Hits))
                .Subscribe(view.Set)
                .AddTo(this.subscriptions);
        }

        public void Dispose()
        {
            this.signalBus.Unsubscribe<HitSignal>(this.Increment);

            this.subscriptions.Dispose();
        }

        private void Increment()
        {
            var saved = storage.Load(Keys.Hits);
            if (saved < int.MaxValue)
            {
                storage.Save(Keys.Hits, saved + 1);
            }
        }
    }
}