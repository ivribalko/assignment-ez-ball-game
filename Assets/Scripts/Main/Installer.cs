using Zenject;

namespace EZBall.Main
{
    public class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IMain>()
                .To<Main>()
                .AsSingle();
        }
    }
}