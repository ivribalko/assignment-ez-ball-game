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

        public Game(
            Physics physics,
            IScenes scenes,
            Input input)
        {
            this.physics = physics;
            this.scenes = scenes;
            this.input = input;
        }

        public IObservable<Unit> Run(IPlanet planet)
        {
            return scenes.Add(Scene.Game)
                .Do(_ => physics.Set(planet))
                .ContinueWith(this.input.OnBack.Take(1))
                .DoOnError(Debug.LogException)
                .CatchIgnore()
                .Do(_ => physics.Restore())
                .ContinueWith(scenes.Unload(Scene.Game));
        }
    }
}