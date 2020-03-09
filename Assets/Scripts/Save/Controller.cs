using System;
using EZBall.Rife;
using UniRx;
using Zenject;

namespace EZBall.Save
{
    internal class Controller : IDisposable
    {
        private readonly HitView view;
        private readonly Storage storage;
        private readonly SignalBus signalBus;

        private readonly CompositeDisposable subscriptions = new CompositeDisposable();

        private Controller(
            HitView view,
            Storage storage,
            SignalBus signalBus)
        {
            this.view = view;
            this.storage = storage;
            this.signalBus = signalBus;

            this.view.Hide();

            this.signalBus.Subscribe<HitSignal>(this.Increment);
            this.signalBus.Subscribe<SceneSignal>(this.Toggle);

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
            this.signalBus.Unsubscribe<SceneSignal>(this.Toggle);
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

        private void Toggle(SceneSignal scene)
        {
            if (scene.SceneOpened == Scene.Main ||
                scene.SceneClosed == Scene.Game)
            {
                this.view.Show();
            }
            else
            {
                this.view.Hide();
            }
        }
    }
}