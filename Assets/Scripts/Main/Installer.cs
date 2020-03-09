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
                .BindIFactory<MainView>()
                .FromComponentInNewPrefabResource("MainView")
                .UnderTransform(_ => this.Container.Resolve<Canvas>().transform);

            this.Container
                .Bind<Lazy<MainView>>()
                .FromResolveGetter<IFactory<MainView>>(view => new Lazy<MainView>(view.Create));

            this.Container
                .Bind<MainButton.Factory>()
                .WhenInjectedInto<MainView>();

            this.Container
                .Bind<IMain>()
                .To<Main>()
                .AsSingle();
        }

    }
}