using System;
using UnityEngine;
using Zenject;

namespace EZBall.Main
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindIFactory<MainButton>()
                .FromComponentInNewPrefabResource("MainButton");

            this.Container
                .BindIFactory<View>()
                .FromComponentInNewPrefabResource("MainView")
                .UnderTransform(_ => this.Container.Resolve<Canvas>().transform);

            this.Container
                .Bind<Lazy<View>>()
                .FromResolveGetter<IFactory<View>>(view => new Lazy<View>(view.Create));

            this.Container
                .Bind<MainButton.Factory>()
                .WhenInjectedInto<View>();

            this.Container
                .Bind<IMain>()
                .To<Main>()
                .AsSingle();
        }

    }
}