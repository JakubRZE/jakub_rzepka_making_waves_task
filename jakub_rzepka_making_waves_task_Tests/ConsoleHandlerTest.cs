using jakub_rzepka_making_waves_task;
using jakub_rzepka_making_waves_task.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Xunit;

namespace jakub_rzepka_making_waves_task_Tests
{
    public class ConsoleHandlerTest
    {
        readonly ConsoleHandler _dateRange;
        readonly Mock<IConsole> _consoleMock;
        public ConsoleHandlerTest()
        {
            _consoleMock = new Mock<IConsole>();
            _dateRange = new ConsoleHandler(_consoleMock.Object);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pl-PL");
        }
        [Fact]
        public void ShouldDisplayMessageGivenIncorrectDate()
        {
            List<string> consoleOutput =  PrepareFakeConsole("02.01.202000", "02.01.2020", "03.01.2020");

            _dateRange.CompareInputDates();

            Assert.Equal(jakub_rzepka_making_waves_task.Texts.IncorrectDate, consoleOutput[1]);
        }

        

        [Fact]
        public void ShouldDisplayMessageGivenSameDates()
        {
            var consoleOutput = PrepareFakeConsole( "02.01.2020", "02.01.2020", "03.01.2020");

            _dateRange.CompareInputDates();

            Assert.Equal(jakub_rzepka_making_waves_task.Texts.DatesMustBeDifferent, consoleOutput[2]);
        }

        [Fact]
        public void ShouldDisplayMessageGivenCorrectDates()
        {
            var consoleOutput = PrepareFakeConsole("02.01.2020", "03.01.2020");

            _dateRange.CompareInputDates();

            Assert.Equal("02-03.01.2020", consoleOutput[2]);
        }


        private List<string> PrepareFakeConsole(params string[] consoleInput)
        {
            List<string> consoleOutput = new List<string>();
            int currentConsoleInput = 0;
            _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>()))
                .Callback<string>(x => consoleOutput.Add(x));

            _consoleMock.Setup(x => x.ReadLine())
                .Returns(() => consoleInput[currentConsoleInput++]);

            return consoleOutput;
        }
    }
}
