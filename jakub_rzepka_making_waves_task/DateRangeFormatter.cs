using System;
using System.Globalization;

namespace jakub_rzepka_making_waves_task
{
    public class DateRangeFormatter
    {
        public Range GetFormattedRange(DateTime startDate, DateTime endDate)
        {
            var formatedStartDate = GetFormatedStartDate(startDate, endDate);
            return new Range { StartRange = formatedStartDate, EndRange = endDate.ToShortDateString() };
        }

        private string GetFormatedStartDate(DateTime startDate, DateTime endDate)
        {
            var dateSeparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

            var splitedStartDate = startDate.ToShortDateString().Split(dateSeparator);
            var splitedEndtDate = endDate.ToShortDateString().Split(dateSeparator);

            if (splitedStartDate[2] != splitedEndtDate[2])
                return startDate.ToShortDateString();
            if (splitedStartDate[1] != splitedEndtDate[1])
                return $"{splitedStartDate[0]}{dateSeparator}{splitedStartDate[1]}";
            return splitedStartDate[0];
        }
    }

    public class Range
    {
        public string StartRange { get; set; }
        public string EndRange { get; set; }
    }
}
