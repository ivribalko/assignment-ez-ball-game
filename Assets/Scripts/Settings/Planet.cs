using System;
using UnityEngine;

namespace EZBall.Settings
{
    [Serializable]
    internal class Planet : IPlanet
    {
        public string Name => this.name;

        [SerializeField] private string name;
    }
}