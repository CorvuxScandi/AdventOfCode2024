using System;

namespace AdventCalendar;

public interface IDay
{
    public Task<CalendarAnswer> Run();

    public Task<CalendarAnswer> RunAdvanced();

}
