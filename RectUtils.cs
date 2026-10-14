namespace RaylibExt;

public partial class Rect
{
  public static Rectangle GetRectangleFromPoints(Vector2[] points)
  {
    float minX = points.Min(point => point.X);
    float minY = points.Min(point => point.Y);
    float maxX = points.Max(point => point.X);
    float maxY = points.Max(point => point.Y);

    return new(
      minX, minY,
      maxX-minX, maxY-minY
    );
  }
}
