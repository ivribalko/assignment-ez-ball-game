namespace EZBall.Rife
{
    public class SceneSignal
    {
        public readonly Scene? SceneOpened;
        public readonly Scene? SceneClosed;

        public SceneSignal(
            Scene? sceneOpened,
            Scene? sceneClosed)
        {
            this.SceneOpened = sceneOpened;
            this.SceneClosed = sceneClosed;
        }
    }
}