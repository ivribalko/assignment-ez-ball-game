using System;
using System.Collections.Generic;
using EZBall.Settings;

namespace EZBall.Main
{
    internal class Main : IMain
    {
        private readonly Lazy<View> view;
        private readonly IEnumerable<IPlanet> planets;

        internal Main(Lazy<View> view, IEnumerable<IPlanet> planets)
        {
            this.view = view;
            this.planets = planets;
        }

        public IObservable<IPlanet> Run()
        {
            return this.view.Value.OnClick(this.planets);
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