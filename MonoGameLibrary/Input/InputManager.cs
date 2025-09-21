using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Input;

public class InputManager
{
    /// <summary>
    /// Gets the state information of keyboard input
    /// </summary>
    public KeyboardInfo Keyboard { get; private set; }

    /// <summary>
    /// Gets the state information of mouse input
    /// </summary>
    public MouseInfo Mouse { get; private set; }

    /// <summary>
    /// Gets the state information of gamepads.
    /// </summary>
    public GamePadInfo[] GamePads { get; private set; }

    public InputManager()
    {
        Keyboard = new KeyboardInfo();
        Mouse = new MouseInfo();
        GamePads = new GamePadInfo[4];
        for (int i = 0; i < GamePads.Length; i++)
        {
            GamePads[i] = new GamePadInfo( (PlayerIndex) i);
        }
    }

    public void Update(GameTime gameTime)
    {
        Keyboard.Update();
        Mouse.Update();
        for (int i = 0; i < GamePads.Length; i++)
        {
            GamePads[i].Update(gameTime);
        }
    }

}