using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EZBall.Game
{
    internal class Platform : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] internal SpriteRenderer sprite;

        internal IObservable<Unit> OnPointerClickAsObservable => this.onPointerClick;

        private readonly Subject<Unit> onPointerClick = new Subject<Unit>();

        private void OnDestroy()
        {
            this.onPointerClick.Dispose();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            this.onPointerClick.OnNext(default);
        }

        internal void Set(Color color)
        {
            this.sprite.color = color;
        }
    }
}