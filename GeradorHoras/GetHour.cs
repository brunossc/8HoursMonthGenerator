namespace GeradorHoras
{
    internal static class GetHour
    {
        private static readonly int[] _starthours = new int[] { 8, 9 };
        private static readonly int[] _startMinuts = new int[] { 30, 45 };
        private static readonly int[] _diffMinuts = new int[] { 0, 15 };
        private static readonly TimeSpan _defaultDay = TimeSpan.FromHours(8);
        private static readonly Random _random = new Random();

        public static string Get(int day, int month)
        {
            var date = new DateTime(DateTime.Now.Year, month, day);
            var startHour = _random.Next(_starthours[0], _starthours[1]);
            var starMinuts = _random.Next(_startMinuts[0], _startMinuts[1]);
            var diffMinuts = _random.Next(_diffMinuts[0], _diffMinuts[1]);

            var interval1 = new DateTime(date.Year, date.Month, date.Day, startHour, starMinuts, 0);
            var interval2 = interval1.AddHours(4).AddMinutes(diffMinuts);

            diffMinuts = _random.Next(_diffMinuts[0], _diffMinuts[1]);
            var interval3 = interval2.AddHours(1).AddMinutes(diffMinuts);

            diffMinuts = _random.Next(_diffMinuts[0], _diffMinuts[1]);
            var interval4 = interval3.AddHours(4).AddMinutes(diffMinuts);

            var time = ((interval2 - interval1) + (interval4 - interval3));

            if (time != _defaultDay)
                interval4 = interval4.AddTicks((_defaultDay - time).Ticks);

            time = ((interval2 - interval1) + (interval4 - interval3));

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return date.DayOfWeek.ToString();
            else
                return interval1.ToString("HH:mm") + " - " + interval2.ToString("HH:mm") + " - " + interval3.ToString("HH:mm") + " - " + interval4.ToString("HH:mm") + " > " + time;
        }
    }
}
