using jakub_rzepka_making_waves_task;
using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace jakub_rzepka_making_waves_task_Tests
{
    public class DateRangeTest
    {
        readonly DateRangeFormatter _dateRangeFormatter;
        public DateRangeTest()
        {
            _dateRangeFormatter = new DateRangeFormatter();
        }
        [Theory]
        [InlineData("02/01/2020", "01/01/2020", "2", "1/1/2020", "en-US")]
        [InlineData("01/02/2020", "01/01/2020", "1/2", "1/1/2020", "en-US")]
        [InlineData("01/01/2022", "01/01/2020", "1/1/2022", "1/1/2020", "en-US")]
        [InlineData("03/03/2023", "01/01/2020", "3/3/2023", "1/1/2020", "en-US")]
        [InlineData("01/01/2020", "02/01/2020", "1", "2/1/2020", "en-US")]
        [InlineData("01/01/2020", "01/02/2020", "1/1", "1/2/2020", "en-US")]
        [InlineData("01/01/2020", "01/01/2022", "1/1/2020", "1/1/2022", "en-US")]
        [InlineData("01/01/2020", "03/03/2023", "1/1/2020", "3/3/2023", "en-US")]

        [InlineData("02.01.2020", "01.01.2020", "02", "01.01.2020", "pl-PL")]
        [InlineData("01.02.2020", "01.01.2020", "01.02", "01.01.2020", "pl-PL")]
        [InlineData("01.01.2022", "01.01.2020", "01.01.2022", "01.01.2020", "pl-PL")]
        [InlineData("03.03.2023", "01.01.2020", "03.03.2023", "01.01.2020", "pl-PL")]
        [InlineData("01.01.2020", "02.01.2020", "01", "02.01.2020", "pl-PL")]
        [InlineData("01.01.2020", "01.02.2020", "01.01", "01.02.2020", "pl-PL")]
        [InlineData("01.01.2020", "01.01.2022", "01.01.2020", "01.01.2022", "pl-PL")]
        [InlineData("01.01.2020", "03.03.2023", "01.01.2020", "03.03.2023", "pl-PL")]

        [InlineData("02/01/2020", "01/01/2020", "02", "01/01/2020", "es-ES")]
        [InlineData("01/02/2020", "01/01/2020", "01/02", "01/01/2020", "es-ES")]
        [InlineData("01/01/2022", "01/01/2020", "01/01/2022", "01/01/2020", "es-ES")]
        [InlineData("03/03/2023", "01/01/2020", "03/03/2023", "01/01/2020", "es-ES")]
        [InlineData("01/01/2020", "02/01/2020", "01", "02/01/2020", "es-ES")]
        [InlineData("01/01/2020", "01/02/2020", "01/01", "01/02/2020", "es-ES")]
        [InlineData("01/01/2020", "01/01/2022", "01/01/2020", "01/01/2022", "es-ES")]
        [InlineData("01/01/2020", "03/03/2023", "01/01/2020", "03/03/2023", "es-ES")]
        public void ShouldReturnDatesInCultureSpecificFormatGivenTwoDates(string startDate, string endDate, string expectedResultStartDate, string expectedResultendDate, string culture)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);

            var formattedRange = _dateRangeFormatter.GetFormattedRange(DateTime.Parse(startDate), DateTime.Parse(endDate));

            Assert.Equal(expectedResultStartDate, formattedRange.StartRange);
            Assert.Equal(expectedResultendDate, formattedRange.EndRange);
        }
    }
}
