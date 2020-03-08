using EZBall.Game;
using EZBall.Main;
using Zenject;

namespace EZBall.Core
{
    internal class ProjectContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IMain>()
                .FromInstance(null);

            this.Container
                .Bind<IGame>()
                .FromInstance(null);

            Settings.Installer.Install(this.Container);

            this.Container
                .Bind<Bootstrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}