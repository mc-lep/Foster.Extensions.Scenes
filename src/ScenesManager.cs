using Foster.Framework.Extensions.Scenes.Transitions;

namespace Foster.Framework.Extensions.Scenes
{
    public sealed class ScenesManager
    {
        private readonly Batcher _batch = new();
        private Scene _currentScene = Scene.Empty;
        private Transition? _transition;

        public void SwitchToScene(Scene scene)
        {
            scene.SetManager(this);
            _currentScene = scene;
        }

        public void SwitchToScene(Scene scene, Transition transition)
        {
            _transition = transition;
            _transition.OnInState += () => SwitchToScene(scene);
            _transition.OnCompleted += () => { _transition = null; };
        }

        public void Update()
        {
            _currentScene.Update();
            _transition?.Update();
        }

        public void Render()
        {
            _currentScene.Render();

            if (_transition != null)
            {
                _transition.Render(_batch);
                _batch.Render();
                _batch.Clear();
            }
        }
    }
}
