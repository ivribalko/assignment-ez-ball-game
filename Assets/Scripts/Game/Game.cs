using System;
using EZBall.Core;
using EZBall.Settings;
using UniRx;

namespace EZBall.Game
{
    internal class Game : IGame
    {
        private readonly IScenes scenes;

        public Game(IScenes scenes)
        {
            this.scenes = scenes;
        }

        public IObservable<Unit> Run(IPlanet planet)
        {
            return scenes
                .Add(Scene.Game)
                .Delay(TimeSpan.FromSeconds(1))
                .Select(_ => scenes.Unload(Scene.Game))
                .Switch();
        }
    }
}