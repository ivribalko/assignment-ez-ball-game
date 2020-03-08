using Zenject;

namespace EZBall.Core
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            this.Container
                .DeclareSignal<InitSignal>();

            this.Container
                .Bind<IInit>()
                .To<Init>()
                .AsSingle();

            this.Container
                .Bind<IScenes>()
                .To<Scenes>()
                .AsSingle();
        }
    }
}