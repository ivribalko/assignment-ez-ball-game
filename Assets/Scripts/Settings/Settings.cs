using UnityEngine;

namespace EZBall.Settings
{
    [CreateAssetMenu(
        fileName = "Settings",
        menuName = "Assets/Scripts/Settings/Settings.cs/Settings")]
    internal class Settings : ScriptableObject
    {
        [SerializeField] internal Planet[] planets;
    }
}