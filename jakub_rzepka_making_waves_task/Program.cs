
namespace jakub_rzepka_making_waves_task
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateRange = new ConsoleHandler(new Console());
            dateRange.CompareInputDates();
        }
    }
}
