using System;
using UniRx;
using UnityEngine;

namespace EZBall.Save
{
    internal class Storage
    {
        internal IObservable < (string key, int value) > OnSaved => this.onSaved;

        private Subject < (string key, int value) > onSaved = new Subject < (string key, int value) > ();

        internal int Load(string key) => PlayerPrefs.GetInt(key);

        internal void Save(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();

            this.onSaved.OnNext((key, value));
        }
    }
}