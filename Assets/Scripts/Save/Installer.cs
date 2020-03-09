using Zenject;

namespace EZBall.Save
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<Storage>()
                .AsSingle();

            this.Container
                .Bind<Runner>()
                .AsSingle()
                .NonLazy();
        }
    }
}