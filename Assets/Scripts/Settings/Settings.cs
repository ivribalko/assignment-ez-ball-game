using System.Collections.Generic;
using UnityEngine;

namespace EZBall.Settings
{
    internal class Settings : ISettings
    {
        public IEnumerable<IPlanet> Planets { get; }

        private Settings()
        {
            this.Planets = Resources
                .Load<Planets>("Planets")
                .list;
        }
    }
}