using Foster.Framework;
using Foster.Framework.Extensions.Scenes;
using System.Numerics;

namespace Scenes.Samples.Scenes
{
    internal abstract class TextScene : Scene
    {
        public static readonly string FontsPath = Path.Combine("Content", "Fonts");
        public static readonly SpriteFont _titleFont = new(Path.Combine(FontsPath, "Poppins-Black.ttf"), 38);
        public static readonly SpriteFont _messageFont = new(Path.Combine(FontsPath, "Poppins-Regular.ttf"), 26);

        public string Title { get; }
        public Vector2 TitlePosition { get; }

        public string Message { get; }
        public Vector2 MessagePosition { get; }

        public TextScene(string title, string message)
        {
            Title = title;
            TitlePosition = new Vector2((App.Width - _titleFont.WidthOfLine(Title)) * 0.5f, App.Height * 0.5f - _titleFont.HeightOf(Title));

            Message = message;
            MessagePosition = new Vector2((App.Width - _messageFont.WidthOfLine(Message)) * 0.5f, App.Height * 0.5f + 15);
        }

        public override void Render()
        {
            Graphics.Clear(Color.Black);

            Batch.Text(_titleFont, Title, TitlePosition, Color.White);
            Batch.Text(_messageFont, Message, MessagePosition, Color.LightGray);

            Batch.Render();
            Batch.Clear();
        }
    }
}
