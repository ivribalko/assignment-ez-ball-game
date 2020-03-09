using UnityEngine;

namespace EZBall.Settings
{
    public interface IPlanet
    {
        string Name { get; }
        Color Color { get; }
        Vector2 Gravity { get; }
    }
}