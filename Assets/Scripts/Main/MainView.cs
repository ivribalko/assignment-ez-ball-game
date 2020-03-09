using System;
using System.Collections.Generic;
using System.Linq;
using EZBall.Rife;
using EZBall.Settings;
using UniRx;
using UnityEngine;
using Zenject;

namespace EZBall.Main
{
    internal class MainView : MonoBehaviour, IView
    {
        [SerializeField] Transform buttonLayout;

        private MainButton.Factory buttonFactory;

        [Inject]
        private void InjectMeWith(MainButton.Factory buttonFactory)
        {
            this.buttonFactory = buttonFactory;
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        internal IObservable<IPlanet> OnClick(IEnumerable<IPlanet> planets)
        {
            return planets
                .Select(OnClick)
                .Merge();
        }

        internal IObservable<IPlanet> OnClick(IPlanet planet)
        {
            return this.buttonFactory
                .Create(planet.Name, buttonLayout)
                .Select(_ => planet);
        }
    }
}