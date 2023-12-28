using Foster.Framework;
using Foster.Framework.Extensions.Scenes.Transitions;

namespace Scenes.Samples.Scenes
{
    internal class Scene2 : TextScene
    {
        public Scene2()
            : base("Second Scene", "Press [Space] to return to first scene with a transition")
        {

        }

        public override void Update()
        {
            if (Input.Keyboard.Pressed(Keys.Space))
            {
                SwitchToScene(
                    new Scene1(), 
                    new ColorFadeTransition(Color.White, 1f, Ease.QuadOut)
                );
            }
        }
    }
}