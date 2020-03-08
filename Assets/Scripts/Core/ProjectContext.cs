using EZBall.Game;
using EZBall.Main;
using EZBall.Settings;
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

            this.Container
                .Bind<ISettings>()
                .FromInstance(null);

            this.Container
                .Bind<Bootstrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}