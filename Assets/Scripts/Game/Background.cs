using EZBall.Settings;
using UnityEngine;

namespace EZBall.Game
{
    internal class Background
    {
        private Background(Camera camera, IPlanet planet)
        {
            camera.backgroundColor = planet.Color;
        }
    }
}