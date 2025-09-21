using Microsoft.Xna.Framework.Input;

namespace MonoGameLibrary.Input;

public class KeyboardInfo
{
    /// <summary>
    /// Gets the state of keyboard input during the previous update cycle.
    /// </summary>
    public KeyboardState PreviousState { get; private set; }

    /// <summary>
    /// Gets the state of keyboard input during the current input cycle.
    /// </summary>
    public KeyboardState CurrentState { get; private set; }

    /// <summary>
    /// Creates a new KeyboardInfo.
    /// </summary>
    public KeyboardInfo()
    {
        PreviousState = new KeyboardState();
        CurrentState = Keyboard.GetState();
    }

    /// <summary>
    /// Updates the state info about keyboard input.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Keyboard.GetState();
    }

    // Methods to check keyboard states

    /// <summary>
    /// Returns a true if the specified key is currently down.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if the specified key is currently down; otherwise, false</returns>
    public bool IsKeyDown(Keys key) => CurrentState.IsKeyDown(key);

    /// <summary>
    /// Returns true if the specified key is currently up
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if the specified key is currently up; otherwise, false</returns>
    public bool IsKeyUp(Keys key) => CurrentState.IsKeyUp(key);

    /// <summary>
    /// Returns true if the specified key was just pressed on the current frame.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if the specified key was just pressed; otherwise, false</returns>
    public bool WasKeyJustPressed(Keys key)
    {
        return CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);
    }

    /// <summary>
    /// Returns true if the specified key was just released on the current frame.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if the specified key was just released; otherwise, false</returns>
    public bool WasKeyJustReleased(Keys key)
    {
        return PreviousState.IsKeyDown(key) && CurrentState.IsKeyUp(key);
    }

}