using System;
using EZBall.Settings;
using UnityEngine;

namespace EZBall.Game
{
    internal class Physics : IDisposable
    {
        Vector2 saved;

        private Physics(IPlanet planet)
        {
            this.saved = Physics2D.gravity;

            Physics2D.gravity = planet.Gravity;
        }

        public void Dispose()
        {
            Physics2D.gravity = saved;
        }
    }
}