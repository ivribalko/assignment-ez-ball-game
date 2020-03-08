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

        public Game(IScenes scenes, Input input)
        {
            this.scenes = scenes;
            this.input = input;
        }

        public IObservable<Unit> Run(IPlanet planet)
        {
            return scenes.Add(Scene.Game)
                .ContinueWith(_ => this.input
                    .OnBack()
                    .Take(1))
                .DoOnError(Debug.LogException)
                .CatchIgnore()
                .ContinueWith(scenes.Unload(Scene.Game));
        }
    }
}