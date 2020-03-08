using System;
using Zenject;

namespace EZBall.Main
{
    public class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindIFactory<View>()
                .FromComponentInNewPrefabResource("MainView");

            this.Container
                .Bind<Lazy<View>>()
                .FromResolveGetter<IFactory<View>>(view => new Lazy<View>(view.Create));

            this.Container
                .Bind<IMain>()
                .To<Main>()
                .AsSingle();
        }
    }
}