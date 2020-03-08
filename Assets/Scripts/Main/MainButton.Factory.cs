using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace EZBall.Main
{
    internal sealed partial class MainButton
    {
        internal sealed class Factory : IFactory<string, Transform, IObservable<Unit>>
        {
            private readonly IFactory<MainButton> prefabFactory;

            private Factory(IFactory<MainButton> prefabFactory)
            {
                this.prefabFactory = prefabFactory;
            }

            public IObservable<Unit> Create(string param1, Transform param2)
            {
                return this.prefabFactory
                    .Create()
                    .SetParent(param2)
                    .SetText(param1)
                    .button
                    .OnClickAsObservable();
            }
        }
    }
}