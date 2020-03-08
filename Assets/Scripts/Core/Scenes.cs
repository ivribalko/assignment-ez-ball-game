using System;
using UniRx;
using UnityEngine.SceneManagement;

namespace EZBall.Core
{
    internal class Scenes : IScenes
    {
        public IObservable<Unit> Add(Scene scene)
        {
            return this.Load(scene, LoadSceneMode.Additive);
        }

        public IObservable<Unit> Load(Scene scene)
        {
            return this.Load(scene, LoadSceneMode.Single);
        }

        public IObservable<Unit> Unload(Scene scene)
        {
            return SceneManager
                .UnloadSceneAsync(scene.ToString())
                .AsObservable()
                .AsUnitObservable();
        }

        private IObservable<Unit> Load(Scene scene, LoadSceneMode mode)
        {
            return SceneManager
                .LoadSceneAsync(scene.ToString(), mode)
                .AsObservable()
                .AsUnitObservable();
        }
    }
}