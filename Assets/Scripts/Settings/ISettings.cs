using System.Collections.Generic;

namespace EZBall.Settings
{
    /// <summary>
    /// Configuration facade.
    /// </summary>
    public interface ISettings
    {
        IEnumerable<IPlanet> Planets { get; }
    }
}