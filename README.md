<p align="center">
  This repository contains the <strong>FosterFramework.Extensions.Scenes</strong> source code.
</p>

<p align="center">
	<a href="#introduction">Introduction</a> &nbsp;&bull;&nbsp;
	<a href="#installation">Installation</a> &nbsp;&bull;&nbsp;
	<a href="#usage">Usage</a> &nbsp;&bull;&nbsp;
	<a href="#documentation">Documentation</a> &nbsp;&bull;&nbsp;
	<a href="#samples">Samples</a>
</p>

# Introduction
This `FosterFramework.Extensions.Scenes` library provides simple api to implements scenes managment in your `FosterFramework` game.

## Installation

#### Nuget

```
dotnet add package FosterFramework.Extensions.Scenes
```

#### Include project

- Clone the project `git clone https://github.com/mc-lep/Foster.Extensions.Scenes.git`
- Add a reference to the cloned project

## Usage
Sample code that shows how to use the library:
```cs
ScenesManager scenesManager = new();
scenesManager.SwitchToScene(new Scene1()); 
```
The other available methods are described in the next section.

## Documentation

To use the library, you must follow these three steps

### 1. Create a Scene

A scene is just a class which will be updated and rendered at each frame. It's supposed to have all the logic of a GameState of your game (ex: Setting, Title screen, Gameplay, ...)

To create a scene just inihirit from the base Scene class and implements the Update and Render methods.

```cs
internal class TitleScene : Scene
{
    public static readonly string FontsPath = Path.Combine("Content", "Fonts");
    public static readonly SpriteFont _titleFont = new(Path.Combine(FontsPath, "Poppins-Black.ttf"), 38);

    public string Title { get; }
    public Vector2 TitlePosition { get; }

    public TitleScene(string title, string message)
    {
        Title = title;
        TitlePosition = new Vector2((App.Width - _titleFont.WidthOfLine(Title)) * 0.5f, App.Height * 0.5f - _titleFont.HeightOf(Title));
    }

    public override void Render()
    {
        Graphics.Clear(Color.Black);

        Batch.Text(_titleFont, Title, TitlePosition, Color.White);
        
        Batch.Render();
        Batch.Clear();
    }
}
```

### 2. Initialize scene manager

Impletent a new Game Module and initialize a ScenesManager.


```cs
internal class GameRoot : Module
{
    private readonly ScenesManager _scenesManager = new();

    public override void Update()
    {
        _scenesManager.Update();
    }

    public override void Render()
    {
        _scenesManager.Render();
    }
}
```

### 3. Show you scene

Call the method `SwitchToScene`, and the `ScenesManager` will update and render your scene at each frame.


```cs
internal class GameRoot : Module
{
    private readonly ScenesManager _scenesManager = new();

    public override void Startup()
    {
        _scenesManager.SwitchToScene(new TitleScene()); // Swicth to your scene
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
```
You can add transitions when switching to your scene by passing a transition object in method `SwitchToScene`

```cs
public override void Startup()
{
	_scenesManager.SwitchToScene(new TitleScene(), new ColorFadeTransition(Color.White, 1f, Ease.QuadOut)); // Swicth to your scene using a transition
}

```

#### Included transitions

 - `ColorFadeTransition` : Blend your screen to a `Color` and then the next screen from this `Color`


 ## Samples

 A samples project is included in the repository, you can found it [here](https://github.com/mc-lep/Foster.Extensions.Scenes/tree/main/samples/Scenes.Samples)