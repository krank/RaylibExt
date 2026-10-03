namespace RaylibExt;

public class Rect
{
  private Rectangle _rect;

  public Rect() { _rect = new(); }
  public Rect(Vector2 position, Vector2 size) { _rect = new(position, size); }
  public Rect(Vector2 position, float width, float height) { _rect = new(position, width, height); }
  public Rect(float x, float y, Vector2 size) { _rect = new(x, y, size); }
  public Rect(float x, float y, float width, float height) { _rect = new(x, y, width, height); }

  public Rect(Rectangle rectangle) { _rect = rectangle; }

  public float Y => _rect.Y;
  public float X => _rect.X;

}