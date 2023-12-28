namespace Foster.Framework.Extensions.Scenes.Transitions
{
    public class ColorFadeTransition(Color color, float durationInSeconds, Ease.Easer? easer = null) 
        : Transition(durationInSeconds)
    {
        public Color Color { get; } = color;
        public Ease.Easer Easer { get; } = easer ?? Ease.Linear;

        public override void Render(Batcher batcher)
        {
            batcher.Rect(0, 0, App.Width, App.Height, Color * Easer(Progress));
        }
    }
}
