using jakub_rzepka_making_waves_task.Interfaces;

namespace jakub_rzepka_making_waves_task
{
    public class Console : IConsole
    {
        public string ReadLine() => System.Console.ReadLine();
        public void WriteLine(string value) => System.Console.WriteLine(value);
    }
}
