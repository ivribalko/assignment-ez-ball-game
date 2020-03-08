using System;
using EZBall.Core;
using EZBall.Settings;
using UniRx;
using UnityEngine;
using Zenject;

namespace EZBall.Game
{
    internal class Runner : MonoBehaviour
    {
        private Ball ball;
        private Camera cam;
        private Input input;

        [Inject]
        private void InjectMeWith(
            Camera cam,
            Input input,
            Ball ball)
        {
            this.cam = cam;
            this.input = input;
            this.ball = ball;

            this.input
                .OnTouch
                .Select(this.cam.ScreenToWorldPoint)
                .Select(cursor => cursor - this.ball.transform.position)
                .Select(direction => direction.normalized)
                .Subscribe(this.MoveBall)
                .AddTo(this);
        }

        private void MoveBall(Vector3 direction)
        {
            this.ball
                .rigidBody
                .AddForce(direction, ForceMode2D.Impulse);
        }
    }
}