using Foster.Framework.Extensions.Scenes.Transitions;

namespace Foster.Framework.Extensions.Scenes
{
    public abstract class Scene
    {
        public static readonly Scene Empty = new EmptyScene();
        public Batcher Batch { get; } = new Batcher();

        private ScenesManager? _manager;

        public void SetManager(ScenesManager manager)
        {
            _manager = manager;
        }

        public void SwitchToScene(Scene scene)
        {
            if (_manager == null)
            {
                Log.Warning("Scene manager is not set, can't switch to a new scene");
                return;
            }

            _manager.SwitchToScene(scene);
        }

        public void SwitchToScene(Scene scene, Transition transition)
        {
            if (_manager == null)
            {
                Log.Warning("Scene manager is not set, can't switch to a new scene");
                return;
            }

            _manager.SwitchToScene(scene, transition);
        }

        public abstract void Update();

        public abstract void Render();
    }
}
