namespace RaylibExt;

public class Axis
{
  // key positives
  // gamepad positives
  // button positives

  public class AffectorSet
  {
    public List<KeyboardKey> Keys { get; set; } = [];
    public List<(int gamepadIndex, GamepadAxis axis)> Axis { get; set; } = [];
    public List<(int gamepadIndex, GamepadButton button)> Buttons { get; set; } = [];

    public void Add(KeyboardKey key) => Keys.Add(key);
    public void Add(int gamepadIndex, GamepadAxis axis) => Axis.Add((gamepadIndex, axis));
    public void Add(int gamepadIndex, GamepadButton button) => Buttons.Add((gamepadIndex, button));

    public float GetValue()
    {
      // Gamepad axis
      foreach ((int n, GamepadAxis axis) in Axis)
      {
        
      }

      // Gamepad buttons
      foreach ((int n, GamepadButton button) in Buttons) if (Raylib.IsGamepadButtonDown(n, button)) return 1;

      // Keyboard keys
      foreach (KeyboardKey key in Keys) if (Raylib.IsKeyDown(key)) return 1;

      return 0;
    }
  }
}