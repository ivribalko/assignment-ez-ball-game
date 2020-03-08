using Zenject;

namespace EZBall.Core
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IScenes>()
                .To<Scenes>()
                .AsSingle();
        }
    }
}