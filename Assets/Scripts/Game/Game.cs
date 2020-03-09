using System;
using EZBall.Core;
using EZBall.Rife;
using EZBall.Settings;
using UniRx;
using UnityEngine;
using Zenject;

namespace EZBall.Game
{
    internal class Game : IGame
    {
        private readonly Input input;
        private readonly IScenes scenes;
        private readonly DiContainer container;

        public Game(
            DiContainer container,
            IScenes scenes,
            Input input)
        {
            this.input = input;
            this.scenes = scenes;
            this.container = container;
        }

        public IObservable<Unit> Run(IPlanet planet)
        {
            return Observable.Defer(() =>
            {
                this.container.BindInstance(planet);

                return scenes.Add(Scene.Game)
                    .ContinueWith(this.input.OnBack.Take(1))
                    .DoOnError(Debug.LogException)
                    .CatchIgnore()
                    .DoOnTerminate(() => this.container.Unbind<IPlanet>())
                    .ContinueWith(scenes.Unload(Scene.Game));
            });

        }
    }
}