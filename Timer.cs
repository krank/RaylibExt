namespace RaylibExt;

public class Timer
{
  private Action _action;
  private float _time;
  private float _maxTime;

  public float Time { get => _time; }

  public Timer(float maxTime, Action action)
  {
    _action = action;
    _maxTime = maxTime;
  }

  /// <summary>
  /// Tick the timer forward by amount (usually deltatime).
  /// If timer reaches max; reset (remembering remainder) and trigger timer's action
  /// </summary>
  /// <param name="amount">The amount to advance the timer by</param>
  public void Tick(float amount)
  {
    _time += amount;
    if (_time > _maxTime)
    {
      _action();
      _time %= _maxTime;
    }
  }
}