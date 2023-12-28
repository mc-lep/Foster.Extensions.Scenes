namespace Foster.Framework.Extensions.Scenes.Transitions
{
    public class ColorFadeTransition(Color color, float durationInSeconds, Ease.Easer? easer = null) 
        : Transition(durationInSeconds, easer)
    {
        public Color Color { get; } = color;

        public override void Render(Batcher batcher)
        {
            batcher.Rect(0, 0, App.Width, App.Height, Color * Progress);
        }
    }
}
