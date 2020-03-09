using System;
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
                .DeclareSignal<HitSignal>();

            this.Container
                .Bind<View>()
                .FromComponentInNewPrefabResource("HitView")
                .UnderTransform(_ => this.Container.Resolve<Canvas>().transform)
                .AsSingle();

            // this.Container
            //     .BindIFactory<View>()
            //     .FromComponentInNewPrefabResource("HitView")
            //     .UnderTransform(_ => this.Container.Resolve<Canvas>().transform);

            // this.Container
            //     .Bind<Lazy<View>>()
            //     .FromResolveGetter<IFactory<View>>(view => new Lazy<View>(view.Create));

            this.Container
                .Bind<Storage>()
                .AsSingle();

            this.Container
                .BindInterfacesTo<Runner>()
                .AsSingle()
                .NonLazy();
        }
    }
}