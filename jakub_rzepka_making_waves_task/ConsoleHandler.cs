using jakub_rzepka_making_waves_task.Interfaces;
using System;

namespace jakub_rzepka_making_waves_task
{
    public class ConsoleHandler
    {
        private readonly IConsole _console;
        private readonly DateRangeFormatter _dateRangeFormatter = new DateRangeFormatter();

        public ConsoleHandler(IConsole console)
        {
            _console = console;
        }

        public  void CompareInputDates()
        {
            _console.WriteLine(string.Format(Texts.EnterStartDate, DateTime.Now.ToShortDateString()));
            DateTime startDate = ReadDateFromConsole();

            _console.WriteLine(string.Format(Texts.EnterEndDate, DateTime.Now.ToShortDateString()));
            DateTime endDate = ReadDateFromConsole(startDate);

            var formattedDates = _dateRangeFormatter.GetFormattedRange(startDate, endDate);
            _console.WriteLine($"{formattedDates.StartRange}-{formattedDates.EndRange}");
        }

        private DateTime ReadDateFromConsole(DateTime? excludedDate = null)
        {
            DateTime date;
            do
            {
                if (!DateTime.TryParse(_console.ReadLine(), out date))
                    _console.WriteLine(Texts.IncorrectDate);
                else if (date == excludedDate)
                    _console.WriteLine(Texts.DatesMustBeDifferent);
                else
                    return date;

            } while (true);
        }
    }
}
