using EZBall.Settings;
using UnityEngine;

namespace EZBall.Game
{
    internal class Physics
    {
        Vector2? saved;

        internal void Set(IPlanet planet)
        {
            if (!saved.HasValue)
            {
                this.saved = Physics2D.gravity;
            }

            Physics2D.gravity = planet.Gravity;
        }

        internal void Restore()
        {
            Physics2D.gravity = this.saved.Value;

            this.saved = null;
        }
    }
}