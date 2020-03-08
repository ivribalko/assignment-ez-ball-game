using System;
using EZBall.Settings;
using UniRx;
using Zenject;

namespace EZBall.Game
{
    public class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IGame>()
                .To<Stub>()
                .AsSingle();
        }

        private class Stub : IGame
        {
            public IObservable<Unit> Run(IPlanet planet)
            {
                return Observable
                    .ReturnUnit()
                    .Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}