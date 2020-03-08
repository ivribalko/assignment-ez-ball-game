using System;
using EZBall.Settings;

namespace EZBall.Main
{
    internal class Main : IMain
    {
        private readonly Lazy<View> view;
        private readonly ISettings settings;

        internal Main(Lazy<View> view, ISettings settings)
        {
            this.view = view;
            this.settings = settings;
        }

        public IObservable<IPlanet> Run()
        {
            return this.view.Value.OnClick(this.settings.Planets);
        }

        public void Show()
        {
            this.view.Value.Show();
        }

        public void Hide()
        {
            this.view.Value.Hide();
        }
    }
}