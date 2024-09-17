

using GeradorHoras;

int monthNumber;
Console.WriteLine("Enter the month number:");
var mes = Console.ReadLine();

if (int.TryParse(mes, out monthNumber) && (monthNumber > 0 || monthNumber < 13))
{
    for (int day = 1; day <= DateTime.DaysInMonth(DateTime.Now.Year, monthNumber); day++)
        Console.WriteLine(day.ToString("00") + " = " + GetHour.Get(day, monthNumber));
}
else
    Console.WriteLine("Invalid month!");


