using EZBall.Game;
using Zenject;

namespace EZBall.Core
{
    internal class ProjectContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            Main.Installer.Install(this.Container);

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