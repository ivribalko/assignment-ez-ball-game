using System.Linq;
using UniRx;
using UniRx.Triggers;
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
            Platform[] platforms,
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
                .Select(direction => new Vector3(direction.x, direction.y, 0f))
                .Select(direction => direction.normalized)
                .Subscribe(this.MoveBall)
                .AddTo(this);

            platforms
                .Select(item => item
                    .OnCollisionEnter2DAsObservable()
                    .AsUnitObservable()
                    .Merge(item.OnPointerClickAsObservable)
                    .Select(_ => item))
                .Merge()
                .Subscribe(this.Colorize)
                .AddTo(this);
        }

        private void MoveBall(Vector3 direction)
        {
            this.ball
                .rigidBody
                .AddForce(direction, ForceMode2D.Impulse);
        }

        private void Colorize(Platform platform)
        {
            platform.Set(Random.ColorHSV());
        }
    }
}