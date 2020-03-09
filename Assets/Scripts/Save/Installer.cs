using EZBall.Rife;
using Zenject;

namespace EZBall.Save
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .DeclareSignal<HitSignal>();

            this.Container
                .Bind<Storage>()
                .AsSingle();

            this.Container
                .BindInterfacesTo<Runner>()
                .AsSingle()
                .NonLazy();
        }
    }
}