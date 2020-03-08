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
            return Observable
                .ReturnUnit()
                .Do(_ => scenes.Add(Scene.Game))
                .Delay(TimeSpan.FromSeconds(1))
                .DoOnTerminate(() => scenes.Unload(Scene.Game));
        }
    }
}