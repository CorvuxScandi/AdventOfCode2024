using AdventCalendar.Days;

namespace AdventCalendar;

public class DayRunner
{
    public async Task<CalendarAnswer> RunDay(int day, bool advanced = false)
    {
        switch (day)
        {
            case 1:

                if (advanced)
                {
                    return await new Day1().RunAdvanced();
                }
               return await new Day1().Run();
           
            case 2:
                if (advanced)
                {
                    return await new Day2().RunAdvanced();
                }
               return await new Day2().Run();
               case 4: 
                if (advanced)
                {
                    return await new Day4().RunAdvanced();
                }
                return await new Day4().Run();
            default:
                return new CalendarAnswer(false, "Day not found");
        }
    }
}

