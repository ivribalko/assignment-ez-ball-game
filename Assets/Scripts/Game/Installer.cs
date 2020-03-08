using UnityEngine;
using Zenject;

namespace EZBall.Game
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<Camera>()
                .FromMethod(() => Camera.main);

            this.Container
                .Bind<Ball>()
                .FromMethod(() => Object.FindObjectOfType<Ball>());

            this.Container
                .Bind<Platform[]>()
                .FromMethod(() => Object.FindObjectsOfType<Platform>());

            this.Container
                .Bind<Input>()
                .AsSingle();

            this.Container
                .Bind<IGame>()
                .To<Game>()
                .AsSingle();
        }
    }
}