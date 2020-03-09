using UnityEngine;

namespace EZBall.Save
{
    internal class Storage
    {
        internal int Load(string key) => PlayerPrefs.GetInt(key);

        internal void Save(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
    }
}