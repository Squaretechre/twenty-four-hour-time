using System;
using Xunit;

namespace TwentyFourHourTime.Tests
{
  public class TwentyFourHourTimeShould
  {
    [Fact]
    public void be_able_to_convert_itself_to_correct_string_representation()
    {
      var time = new TwentyFourHourTime(9, 30);
      Assert.Equal("09:30", time.ToString());
    }

    [Fact]
    public void be_equal_when_the_same_as_another_time_when_explicitly_typed()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(10, 45);
      Assert.True(time1.Equals(time2));
    }

    [Fact]
    public void be_equal_when_same_another_time_that_isnt_explicitly_typed()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = (object) new TwentyFourHourTime(10, 45);
      Assert.True(time1.Equals(time2));
    }

    [Fact]
    public void be_equal_when_the_same_as_another_time_using_equality_operator()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(10, 45);
      Assert.True(time1 == time2);
    }

    [Fact]
    public void be_equal_when_the_same_as_another_time_using_hash_code_comparison()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(10, 45);
      Assert.True(time1.GetHashCode() == time2.GetHashCode());
    }

    [Fact]
    public void not_be_equal_when_different_to_another_time_when_explicitly_typed()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(11, 45);
      Assert.False(time1.Equals(time2));
    }

    [Fact]
    public void not_be_equal_when_different_to_another_time_that_isnt_explicitly_typed()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = (object) new TwentyFourHourTime(11, 45);
      Assert.False(time1.Equals(time2));
    }

    [Fact]
    public void not_be_equal_when_different_to_another_time_using_not_equals_operator()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1 != time2);
    }

    [Fact]
    public void not_be_equal_when_different_to_another_time_using_hash_code_comparison()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(11, 45);
      Assert.True(time1.GetHashCode() != time2.GetHashCode());
    }

    [Fact]
    public void not_be_equal_when_compared_to_null_with_equals()
    {
      Assert.False(new TwentyFourHourTime(10, 45).Equals(null));
    }

    [Fact]
    public void be_able_to_be_compared_to_times_greater_than_it()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1.IsGreaterThan(time2));
    }

    [Fact]
    public void be_able_to_be_compared_to_times_less_than_it()
    {
      var time1 = new TwentyFourHourTime(08, 45);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1.IsLessThan(time2));
    }

    [Fact]
    public void be_able_to_be_compared_to_times_greater_than_it_using_operator()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1 > time2);
    }

    [Fact]
    public void be_able_to_be_compared_to_times_less_than_it_using_operator()
    {
      var time1 = new TwentyFourHourTime(09, 44);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1 < time2);
    }

    [Fact]
    public void be_able_to_be_compared_to_times_greater_than_or_equal_to_it_using_operator()
    {
      var time1 = new TwentyFourHourTime(09, 46);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1 >= time2);
    }

    [Fact]
    public void be_able_to_be_compared_to_times_less_than_or_equal_to_it_using_operator()
    {
      var time1 = new TwentyFourHourTime(09, 44);
      var time2 = new TwentyFourHourTime(09, 45);
      Assert.True(time1 <= time2);
    }

    [Theory]
    [InlineData(01)]
    [InlineData(29)]
    public void be_able_to_determine_whether_between_two_other_times(int minutes)
    {
      var startTime = new TwentyFourHourTime(09, 00);
      var endTime = new TwentyFourHourTime(09, 30);
      var timeInRange = new TwentyFourHourTime(09, minutes);
      Assert.True(timeInRange.IsBetween(startTime, endTime));
    }

    [Theory]
    [InlineData(14)]
    [InlineData(31)]
    public void be_able_to_determine_whether_not_between_two_other_times(int minutes)
    {
      var startTime = new TwentyFourHourTime(19, 15);
      var endTime = new TwentyFourHourTime(19, 30);
      var timeInRange = new TwentyFourHourTime(19, minutes);
      Assert.False(timeInRange.IsBetween(startTime, endTime));
    }

    [Fact]
    public void be_able_to_be_created_from_a_datetime()
    {
      var time1 = new TwentyFourHourTime(10, 45);
      var time2 = TwentyFourHourTime.From(new DateTime(2017, 5, 1, 10, 45, 0));
      Assert.True(time1.Equals(time2));
    }

    [Fact]
    public void throw_when_constructed_with_hours_less_than_zero_or_more_than_twenty_three()
    {
      var lowerBoundHoursException = Record.Exception(() => new TwentyFourHourTime(-1, 30));
      var upperBoundHoursException = Record.Exception(() => new TwentyFourHourTime(24, 30));
      Assert.NotNull(lowerBoundHoursException);
      Assert.NotNull(upperBoundHoursException);
      Assert.IsType<ArgumentOutOfRangeException>(lowerBoundHoursException);
      Assert.IsType<ArgumentOutOfRangeException>(upperBoundHoursException);
    }

    [Fact]
    public void throw_when_constructed_with_minutes_less_than_zero_or_more_than_fifty_nine()
    {
      var lowerBoundMinutesException = Record.Exception(() => new TwentyFourHourTime(9, -1));
      var upperBoundMinutesException = Record.Exception(() => new TwentyFourHourTime(10, 60));
      Assert.NotNull(lowerBoundMinutesException);
      Assert.NotNull(upperBoundMinutesException);
      Assert.IsType<ArgumentOutOfRangeException>(lowerBoundMinutesException);
      Assert.IsType<ArgumentOutOfRangeException>(upperBoundMinutesException);
    }
  }
}