using EZBall.Game;
using EZBall.Main;
using UniRx;
using Zenject;

namespace EZBall
{
    internal class Bootstrap
    {
        [Inject]
        private void InjectMeWith(IMain main, IGame game)
        {
            main.Run()
                .Do(_ => main.Hide())
                .Select(game.Run)
                .Switch()
                .Do(_ => main.Show())
                .Subscribe();
        }
    }
}