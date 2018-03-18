using System;

namespace program.Infrastructure
{
    public class DateLogic
    {
        public DateTime DateValidator(string str)
        {
            DateTime dateTime; //= DateTime.Parse(str);
            if (!DateTime.TryParseExact(str, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateTime))
            {
                throw new Exception("Invalid date, please retry");
            }
            return dateTime;
        }

        public string DateRange(DateTime date1, DateTime date2)
        {
            var result = "";

            if (date1 >= date2)
            {
                throw new Exception("There is no range between dates.");
            }

            if (date1.Month == date2.Month && date1.Year == date2.Year)
            {
                result = date1.Day.ToString("00") + " - " + date2.Date.ToShortDateString();
            }

            if (date1.Month != date2.Month && date1.Year == date2.Year)
            {
                result = date1.Day.ToString("00") + "." + date1.Month.ToString("00") + " - " + date2.Date.ToShortDateString();
            }

            if (date1.Month != date2.Month && date1.Year != date2.Year)
            {
                result = date1.Date.ToShortDateString() + " - " + date2.Date.ToShortDateString();
            }
            return result;
        }
    }
}