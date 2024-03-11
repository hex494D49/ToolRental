namespace ToolRental.Helpers
{
    public class DatetimeDifferenceCalculator
    {
        public static object  GetDifference(DateTime startDateTime, DateTime endDateTime)
        {
            if (endDateTime < startDateTime)
            {
                throw new ArgumentException("Ending datetime must be greater than starting datetime.");
            }

            TimeSpan timeDifference = endDateTime - startDateTime;

            int years = endDateTime.Year - startDateTime.Year;
            int months = (endDateTime.Year - startDateTime.Year) * 12 + endDateTime.Month - startDateTime.Month;
            int days = timeDifference.Days;
            int hours = timeDifference.Hours;
            int minutes = timeDifference.Minutes;
            int seconds = timeDifference.Seconds;

            var result = new
            {
                years,
                months,
                days,
                hours,
                minutes,
                seconds
            };

            return result;
        } 
    }
}
