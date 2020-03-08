using System;
using System.Collections.Generic;
using EZBall.Rife;
using EZBall.Settings;
using UniRx;
using UnityEngine;

namespace EZBall.Main
{
    internal class View : MonoBehaviour, IView
    {
        internal IObservable<IPlanet> OnClick(IReadOnlyCollection<IPlanet> planets)
        {
            return Observable.Never<IPlanet>(null);
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