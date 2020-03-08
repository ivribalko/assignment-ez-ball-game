using EZBall.Settings;
using UnityEngine;

namespace EZBall.Game
{
    internal class Background
    {
        private readonly Camera camera;

        private Background(Camera camera)
        {
            this.camera = camera;
        }

        internal void Set(IPlanet planet)
        {
            this.camera.backgroundColor = planet.Color;
        }
    }
}