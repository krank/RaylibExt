namespace RaylibExt;

public class Game
{
  public Action Update = () => {};
  public Action Draw = () => {};
  public Action Setup = () => {};

  public void Run()
  {
    Setup();
    while (!Raylib.WindowShouldClose())
    {
      Update();
      Draw();
    }
  }
}