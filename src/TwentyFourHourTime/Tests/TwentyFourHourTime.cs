using System;

namespace TwentyFourHourTime.Tests
{
  public sealed class TwentyFourHourTime : IEquatable<TwentyFourHourTime>
  {
    private const int Ignore = 1;
    private const int MinutesInDay = 60;

    public readonly int Hours;
    public readonly int Minutes;
    private readonly DateTime _time;

    public TwentyFourHourTime(int hours, int minutes)
    {
      if (hours < 0 || hours > 23) throw new ArgumentOutOfRangeException(nameof(hours));
      if (minutes < 0 || minutes > 59) throw new ArgumentOutOfRangeException(nameof(minutes));

      Hours = hours;
      Minutes = minutes;
      _time = new DateTime(Ignore, Ignore, Ignore, hours, minutes, Ignore);
    }

    public override string ToString()
      => _time.ToString("hh:mm");

    public override int GetHashCode() 
      => unchecked (((_time.GetHashCode() * 397) ^ Hours) * 397) ^ Minutes;

    public override bool Equals(object obj)
      => Equals(obj as TwentyFourHourTime);

    public bool Equals(TwentyFourHourTime other)
      => TimeIsNotNull(other) && HoursAndMinutesAreEqualFor(this, other);

    public static bool operator ==(TwentyFourHourTime time1, TwentyFourHourTime time2) 
      => HoursAndMinutesAreEqualFor(time1, time2);

    public static bool operator !=(TwentyFourHourTime time1, TwentyFourHourTime time2) 
      => !HoursAndMinutesAreEqualFor(time1, time2);

    public static bool operator >(TwentyFourHourTime time1, TwentyFourHourTime time2)
      => TotalMinutesFor(time1) > TotalMinutesFor(time2);

    public static bool operator <(TwentyFourHourTime time1, TwentyFourHourTime time2)
      => TotalMinutesFor(time1) < TotalMinutesFor(time2);

    public static bool operator >=(TwentyFourHourTime time1, TwentyFourHourTime time2)
      => TotalMinutesFor(time1) >= TotalMinutesFor(time2);

    public static bool operator <=(TwentyFourHourTime time1, TwentyFourHourTime time2)
      => TotalMinutesFor(time1) <= TotalMinutesFor(time2);

    private static int TotalMinutesFor(TwentyFourHourTime time)
      => time.Hours * MinutesInDay + time.Minutes;

    private static bool HoursAndMinutesAreEqualFor(TwentyFourHourTime time1, TwentyFourHourTime time2)
      => time1.Hours == time2.Hours && time1.Minutes == time2.Minutes;

    private static bool TimeIsNotNull(TwentyFourHourTime timeBeingCompared)
      => !ReferenceEquals(null, timeBeingCompared);

    public static TwentyFourHourTime From(DateTime dateTime) 
      => new TwentyFourHourTime(dateTime.Hour, dateTime.Minute);

    public bool IsBetween(TwentyFourHourTime startTime, TwentyFourHourTime endTime)
      => this >= startTime && this <= endTime;

    public bool IsGreaterThan(TwentyFourHourTime time2) 
      => this > time2;

    public bool IsLessThan(TwentyFourHourTime time2) 
      => this < time2;
  }
}