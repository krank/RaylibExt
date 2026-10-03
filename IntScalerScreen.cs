namespace RaylibExt;

public class IntScalerScreen
{
  private RenderTexture2D _renderSurface;
  private readonly int _width;
  private readonly int _height;
  private readonly int _scaling;
  private Vector2 _offset;

  private Rectangle _source;
  private Rectangle _dest;

  public int Width => _width;
  public int Height => _height;

  public IntScalerScreen(int scaling, float ratio) // int for scaling, maybe ratio
  {
    _height = Raylib.GetScreenHeight() / scaling;
    _width = Math.Min(
      (int)(_height * ratio),
      Raylib.GetScreenWidth() / scaling
    );

    _scaling = scaling;

    CommonSetup();
  }

  public IntScalerScreen(int width, int height)
  {
    _height = height;
    _width = width;

    _scaling = Raylib.GetScreenHeight() / _height;
    if (_width * _scaling > Raylib.GetScreenWidth())
    {
      _scaling = Raylib.GetScreenWidth() / _width;
    }

    CommonSetup();
  }

  private void CommonSetup()
  {
    _renderSurface = Raylib.LoadRenderTexture(_width, _height);
    _offset = new(
      (Raylib.GetScreenWidth() - _width * _scaling) / 2,
      (Raylib.GetScreenHeight() - _height * _scaling) / 2
    );

    _dest = new(
      _offset,
      _renderSurface.Texture.Dimensions * _scaling
      );

    _source = new(
      Vector2.Zero,
      _width, -_height
    );
  }

  public void BeginDrawing()
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    Raylib.BeginTextureMode(_renderSurface);
  }

  public void EndDrawing()
  {
    Raylib.EndTextureMode();

    Raylib.DrawTexturePro(
      _renderSurface.Texture,
      _source,
      _dest,
      Vector2.Zero, 0, Color.White);

    Raylib.EndDrawing();
  }

  public Vector2 GetMousePos() =>
    ((Raylib.GetMousePosition() - _offset) / _scaling) - new Vector2(0.5f);

}
