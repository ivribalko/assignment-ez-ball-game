using EZBall.Rife;
using UnityEngine;
using Zenject;

namespace EZBall.Save
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<HitView>()
                .FromComponentInNewPrefabResource("HitView")
                .UnderTransform(_ => this.Container.Resolve<Canvas>().transform)
                .AsSingle();

            this.Container
                .Bind<Storage>()
                .AsSingle();

            this.Container
                .BindInterfacesTo<Controller>()
                .AsSingle()
                .NonLazy();
        }
    }
}