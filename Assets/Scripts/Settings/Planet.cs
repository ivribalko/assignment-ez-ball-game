using System;
using UnityEngine;

namespace EZBall.Settings
{
    [Serializable]
    internal class Planet : IPlanet
    {
        public string Name => this.name;
        public Color Color => this.color;
        public Vector2 Gravity => this.gravity;

        [SerializeField] private string name;
        [SerializeField] private Color color;
        [SerializeField] private Vector2 gravity;
    }
}