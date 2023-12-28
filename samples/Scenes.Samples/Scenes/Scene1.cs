using Foster.Framework;

namespace Scenes.Samples.Scenes
{
    internal class Scene1 : TextScene
    {
        public Scene1()
            : base("First Scene", "Press [Space] to go to next scene")
        {

        }

        public override void Update()
        {
            if (Input.Keyboard.Pressed(Keys.Space))
            {
                SwitchToScene(new Scene2());
            }
        }
    }
}
