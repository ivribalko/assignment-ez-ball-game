using Zenject;

namespace EZBall.Game
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<Input>()
                .AsSingle();

            this.Container
                .Bind<IGame>()
                .To<Game>()
                .AsSingle();
        }
    }
}