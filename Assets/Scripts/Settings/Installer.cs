using Zenject;

namespace EZBall.Settings
{
    public class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<ISettings>()
                .To<Settings>()
                .AsSingle();
        }
    }
}