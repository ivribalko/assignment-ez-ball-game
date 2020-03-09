using System;
using System.Collections.Generic;
using EZBall.Core;
using EZBall.Rife;
using EZBall.Settings;
using UniRx;

namespace EZBall.Main
{
    internal class Main : IMain
    {
        private readonly IScenes scenes;
        private readonly Lazy<MainView> view;
        private readonly IEnumerable<IPlanet> planets;

        internal Main(Lazy<MainView> view, IScenes scenes, IEnumerable<IPlanet> planets)
        {
            this.view = view;
            this.scenes = scenes;
            this.planets = planets;
        }

        public IObservable<IPlanet> Run()
        {
            return this.scenes
                .Load(Scene.Main)
                .ContinueWith(_ => this.view
                    .Value
                    .OnClick(this.planets));
        }

        public void Show()
        {
            this.view.Value.Show();
        }

        public void Hide()
        {
            if (this.view.IsValueCreated)
            {
                this.view.Value.Hide();
            }
        }
    }
}