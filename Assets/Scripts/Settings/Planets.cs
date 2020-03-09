using UnityEngine;

namespace EZBall.Settings
{
    [CreateAssetMenu(
        fileName = "Planets",
        menuName = "Assets/Scripts/Settings/Planets.cs/Planets")]
    internal class Planets : ScriptableObject
    {
        [SerializeField] internal Planet[] list;
    }
}