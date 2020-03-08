using UnityEngine;
using Zenject;

namespace EZBall.Core
{
    internal class ProjectContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            Main.Installer.Install(this.Container);

            Game.Installer.Install(this.Container);

            Settings.Installer.Install(this.Container);

            this.Container
                .Bind<Canvas>()
                .FromComponentInHierarchy()
                .AsSingle();

            this.Container
                .Bind<Bootstrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}