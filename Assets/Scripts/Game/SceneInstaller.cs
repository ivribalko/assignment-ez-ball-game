using UnityEngine;
using Zenject;

namespace EZBall.Game
{
    internal sealed class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        [SerializeField] Ball ball;
        [SerializeField] Camera cam;
        [SerializeField] Platform[] platforms;

        public override void InstallBindings()
        {
            this.Container
                .Bind<Ball>()
                .FromInstance(this.ball);

            this.Container
                .Bind<Camera>()
                .FromInstance(this.cam);

            this.Container
                .Bind<Platform[]>()
                .FromInstance(this.platforms);

            this.Container
                .BindInterfacesAndSelfTo<Physics>()
                .AsSingle()
                .NonLazy();

            this.Container
                .Bind<Background>()
                .AsSingle()
                .NonLazy();

            this.Container
                .BindInterfacesAndSelfTo<Runner>()
                .AsSingle()
                .NonLazy();
        }
    }
}