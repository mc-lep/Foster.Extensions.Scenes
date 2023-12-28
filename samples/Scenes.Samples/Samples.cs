using Foster.Framework;
using Foster.Framework.Extensions.Scenes;
using Scenes.Samples.Scenes;

namespace Scenes.Samples
{
    internal class Samples : Module
    {
        private readonly ScenesManager _scenesManager = new();

        public override void Startup()
        {
            _scenesManager.SwitchToScene(new Scene1());
        }

        public override void Update()
        {
            _scenesManager.Update();
        }

        public override void Render()
        {
            _scenesManager.Render();
        }
    }
}
