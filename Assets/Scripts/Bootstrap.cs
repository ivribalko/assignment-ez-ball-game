using EZBall.Core;
using EZBall.Game;
using EZBall.Main;
using UniRx;

namespace EZBall
{
    internal class Bootstrap
    {
        private Bootstrap(IInit init, IMain main, IGame game)
        {
            init.Done()
                .Select(_ => main.Run())
                .Switch()
                .Do(_ => main.Hide())
                .Select(game.Run)
                .Switch()
                .Do(_ => main.Show())
                .Subscribe();
        }
    }
}