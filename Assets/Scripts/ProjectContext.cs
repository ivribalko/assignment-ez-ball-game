using UnityEngine;
using Zenject;

namespace EZBall
{
    internal class ProjectContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            Core.Installer.Install(this.Container);

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