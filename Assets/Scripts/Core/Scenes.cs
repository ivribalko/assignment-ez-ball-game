using System;
using EZBall.Rife;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace EZBall.Core
{
    internal class Scenes : IScenes
    {
        private readonly SignalBus signalBus;

        private Scenes(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public IObservable<Unit> Add(Rife.Scene scene)
        {
            return this.Load(scene, LoadSceneMode.Additive);
        }

        public IObservable<Unit> Load(Rife.Scene scene)
        {
            return this.Load(scene, LoadSceneMode.Single);
        }

        public IObservable<Unit> Unload(Rife.Scene scene)
        {
            return Observable.Defer(() => SceneManager
                .UnloadSceneAsync(scene.ToString())
                .AsObservable()
                .Do(_ => this.FireSignalClosed(scene))
                .AsUnitObservable());
        }

        private IObservable<Unit> Load(Rife.Scene scene, LoadSceneMode mode)
        {
            return Observable.Defer(() => SceneManager
                .LoadSceneAsync(scene.ToString(), mode)
                .AsObservable()
                .Do(_ => this.FireSignalOpened(scene))
                .AsUnitObservable());
        }

        private void FireSignalClosed(Rife.Scene scene)
        {
            this.signalBus.Fire(new SceneSignal(null, scene));
        }

        private void FireSignalOpened(Rife.Scene scene)
        {
            this.signalBus.Fire(new SceneSignal(scene, null));
        }
    }
}