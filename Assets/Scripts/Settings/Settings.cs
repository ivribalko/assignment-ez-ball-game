using System.Collections.Generic;
using UnityEngine;

namespace EZBall.Settings
{
    internal class Settings : ISettings
    {
        public IReadOnlyCollection<IPlanet> Planets { get; }

        private Settings()
        {
            this.Planets = Resources
                .Load<Planets>("Planets")
                .list;
        }
    }
}