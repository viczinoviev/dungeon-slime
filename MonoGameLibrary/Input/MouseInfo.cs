using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.VisualBasic;

namespace MonoGameLibrary.Input;

public class MouseInfo
{
    /// <summary>
    /// The state of mouse input during the previous update cycle
    /// </summary>
    public MouseState PreviousState { get; private set; }
    /// <summary>
    /// The state of mouse input during the current update cycle
    /// </summary>
    public MouseState CurrentState { get; private set; }

    /// <summary>
    /// Gets or sets the position of the mouse cursor in screen space
    /// </summary>
    public Point Position
    {
        get => CurrentState.Position;
        set => SetPosition(value.X, value.Y);
    }

    /// <summary>
    /// Gets or sets the X position of the mouse cursor in screen space
    /// </summary>
    public int x
    {
        get => CurrentState.X;
        set => SetPosition(value, CurrentState.Y);
    }

    /// <summary>
    /// Gets or sets the Y position of the mouse cursor in screen space
    /// </summary>
    public int y
    {
        get => CurrentState.Y;
        set => SetPosition(CurrentState.X, value);
    }

    /// <summary>
    /// Gets the change in position of the mouse cursor since the last update
    /// </summary>
    public Point PositionDelta => CurrentState.Position - PreviousState.Position;

    /// <summary>
    /// Gets the change in X of the mouse cursor since the last update
    /// </summary>
    public int XDelta => CurrentState.X - PreviousState.X;

    /// <summary>
    /// Gets the change in Y of the mouse cursor since the last update
    /// </summary>
    public int YDelta => CurrentState.Y - PreviousState.Y;

    /// <summary>
    /// Returns true if the mouse was moved since the last update cycle; false otherwise.
    /// </summary>
    public bool WasMoved => PositionDelta != Point.Zero;

    /// <summary>
    /// Gets the current scroll wheel value
    /// </summary>
    public int ScrollWheel => CurrentState.ScrollWheelValue;

    /// <summary>
    /// Gets the difference in scroll wheel values since the last update cycle
    /// </summary>
    public int ScrollWheelDelta => CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;
    
    /// <summary>
    /// Constructs a new MouseInfo
    /// </summary>
    public MouseInfo()
    {
        PreviousState = new MouseState();
        CurrentState = Mouse.GetState();
    }


    /// <summary>
    /// Updates the state info about mouse input.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Mouse.GetState();

    }

    /// <summary>
    /// Returns a value indicating whether the specified button is currently down
    /// </summary>
    /// <param name="button">The mouse button to check</param>
    /// <returns>true if the specified mouse button is currently down; otherwise, false</returns>
    public bool IsButtonDown(MouseButton button)
    {
        return button switch
        {
            MouseButton.Left => CurrentState.LeftButton == ButtonState.Pressed,
            MouseButton.Middle => CurrentState.MiddleButton == ButtonState.Pressed,
            MouseButton.Right => CurrentState.RightButton == ButtonState.Pressed,
            MouseButton.XButton1 => CurrentState.XButton1 == ButtonState.Pressed,
            MouseButton.XButton2 => CurrentState.XButton2 == ButtonState.Pressed,
            _ => false,
        };
    }

    /// <summary>
    /// Returns a value indicating whether the specified button is currently up
    /// </summary>
    /// <param name="button">The mouse button to check</param>
    /// <returns>true if specified mouse button is currently up; otherwise, false</returns>
    public bool IsButtonUp(MouseButton button) {
        return !IsButtonDown(button);
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button was just pressed.
    /// </summary>
    /// <param name="button">The mouse button to check</param>
    /// <returns>true if the specified mouse button was just pressed on the current frame; otherwise, false</returns>
    public bool WasButtonJustPressed(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released;
            case MouseButton.Middle:
                return CurrentState.MiddleButton == ButtonState.Pressed && PreviousState.MiddleButton == ButtonState.Released;
            case MouseButton.Right:
                return CurrentState.RightButton == ButtonState.Pressed && PreviousState.RightButton == ButtonState.Released;
            case MouseButton.XButton1:
                return CurrentState.XButton1 == ButtonState.Pressed && PreviousState.XButton1 == ButtonState.Released;
            case MouseButton.XButton2:
                return CurrentState.XButton2 == ButtonState.Pressed && PreviousState.XButton2 == ButtonState.Released;
            default:
                return false;
        }
    }

    /// <summary>
    /// Returns a value that indicates whether the specified mouse button was just released.
    /// </summary>
    /// <param name="button">The mouse button to check</param>
    /// <returns>true if the specified mouse button was just released on the current frame; otherwise, false</returns>

    public bool WasButtonJustReleased(MouseButton button)
    {
        switch (button)
        {
            case MouseButton.Left:
                return CurrentState.LeftButton == ButtonState.Released && PreviousState.LeftButton == ButtonState.Pressed;
            case MouseButton.Middle:
                return CurrentState.MiddleButton == ButtonState.Released && PreviousState.MiddleButton == ButtonState.Pressed;
            case MouseButton.Right:
                return CurrentState.RightButton == ButtonState.Released && PreviousState.RightButton == ButtonState.Pressed;
            case MouseButton.XButton1:
                return CurrentState.XButton1 == ButtonState.Released && PreviousState.XButton1 == ButtonState.Pressed;
            case MouseButton.XButton2:
                return CurrentState.XButton2 == ButtonState.Released && PreviousState.XButton2 == ButtonState.Pressed;
            default:
                return false;
        }
    }

    public void SetPositon(int x, int y)
    {
        Mouse.SetPosition(x, y);
        CurrentState = new MouseState(
            x,
            y,
            CurrentState.ScrollWheelValue,
            CurrentState.LeftButton,
            CurrentState.MiddleButton,
            CurrentState.RightButton,
            CurrentState.XButton1,
            CurrentState.XButton2
            );
    }
}