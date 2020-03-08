using System.Collections.Generic;
using UnityEngine;

namespace EZBall.Settings
{
    internal class SettingsReader : ISettings
    {
        public IReadOnlyCollection<IPlanet> Planets { get; }

        private SettingsReader()
        {
            this.Planets = Resources
                .Load<Settings>("Settings")
                .planets;
        }
    }
}