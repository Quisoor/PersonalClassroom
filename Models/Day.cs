using System;
using System.Collections.Generic;

namespace PersonalClassroom.Models
{
    public class Day
    {
        public Day(DayOfWeek day)
        {
            this.Number = day;
        }

        public DayOfWeek Number { get; }
        public string Label
        {
            get
            {
                return Number switch
                {
                    DayOfWeek.Monday => "Lundi",
                    DayOfWeek.Tuesday => "Mardi",
                    DayOfWeek.Wednesday => "Mercredi",
                    DayOfWeek.Thursday => "Jeudi",
                    DayOfWeek.Friday => "Vendredi",
                    DayOfWeek.Saturday => "Samedi",
                    DayOfWeek.Sunday => "Dimanche",
                    _ => null,
                };
            }
        }

        public static IEnumerable<Day> GetAlls()
        {
            return new List<Day>
            {
                new Day(DayOfWeek.Monday),
                new Day(DayOfWeek.Tuesday),
                new Day(DayOfWeek.Wednesday),
                new Day(DayOfWeek.Thursday),
                new Day(DayOfWeek.Friday),
                new Day(DayOfWeek.Saturday),
                new Day(DayOfWeek.Sunday)
            };
        }
    }
}
