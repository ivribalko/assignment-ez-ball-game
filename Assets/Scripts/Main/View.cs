using System;
using System.Collections.Generic;
using System.Linq;
using EZBall.Rife;
using EZBall.Settings;
using UniRx;
using UnityEngine;

namespace EZBall.Main
{
    internal class View : MonoBehaviour, IView
    {
        internal IObservable<IPlanet> OnClick(IEnumerable<IPlanet> planets)
        {
            return Observable
                .Interval(TimeSpan.FromSeconds(3))
                .Select(_ => planets.First());
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }
    }
}