using System;
using EZBall.Core;
using EZBall.Settings;
using UniRx;
using UnityEngine;

namespace EZBall.Game
{
    internal class Game : IGame
    {
        private readonly Input input;
        private readonly IScenes scenes;
        private readonly Physics physics;
        private readonly Background background;

        public Game(
            Background background,
            Physics physics,
            IScenes scenes,
            Input input)
        {
            this.background = background;
            this.physics = physics;
            this.scenes = scenes;
            this.input = input;
        }

        public IObservable<Unit> Run(IPlanet planet)
        {
            return scenes.Add(Scene.Game)
                .Select(_ => planet)
                .Do(this.physics.Set)
                .Do(this.background.Set)
                .ContinueWith(this.input.OnBack.Take(1))
                .DoOnError(Debug.LogException)
                .CatchIgnore()
                .DoOnTerminate(physics.Restore)
                .ContinueWith(scenes.Unload(Scene.Game));
        }
    }
}