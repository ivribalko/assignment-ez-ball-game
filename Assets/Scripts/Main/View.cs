using System;
using System.Collections.Generic;
using EZBall.Rife;
using EZBall.Settings;

namespace EZBall.Main
{
    internal class View : IView
    {
        internal IObservable<IPlanet> OnClick(IReadOnlyCollection<IPlanet> planets)
        {
            return null;
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}