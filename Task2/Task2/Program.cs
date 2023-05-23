using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        public struct Record
        {
            public int ClientID;
            public int Year;
            public int Month;
            public int Duration;
        }
        static void Main(string[] args)
        {
           
            List<Record> records = new List<Record> 
            {
                new Record { ClientID = 1, Year = 2021, Month = 1, Duration = 10 },
                new Record { ClientID = 2, Year = 2021, Month = 1, Duration = 20 },
                new Record { ClientID = 1, Year = 2021, Month = 2, Duration = 15 },
                new Record { ClientID = 2, Year = 2021, Month = 2, Duration = 25 },
                new Record { ClientID = 1, Year = 2022, Month = 1, Duration = 30 },
                new Record { ClientID = 2, Year = 2022, Month = 1, Duration = 40 },
                new Record { ClientID = 1, Year = 2022, Month = 2, Duration = 35 },
                new Record { ClientID = 2, Year = 2022, Month = 2, Duration = 45 }
            };

           
             static void CalculateTotalDurationForMonth(List<Record> records)
            {
                var result = records
                    .GroupBy(r => r.Month)
                    .Select(g => new
                    {
                        Month = g.Key,
                        TotalDuration = g.Sum(r => r.Duration)
                    })
                    .OrderByDescending(g => g.TotalDuration)
                    .ThenBy(g => g.Month);

                foreach (var i in result)
                {
                    Console.WriteLine($"Суммарная продолжительность за месяц {i.Month}: {i.TotalDuration}");
                    var monthlyRecords = records
                        .Where(r => r.Month == i.Month)
                        .GroupBy(r => r.Year)
                        .Select(g => new
                        {
                            Year = g.Key,
                            TotalDuration = g.Sum(r => r.Duration)
                        })
                        .OrderBy(g => g.Year);

                    foreach (var record in monthlyRecords)
                    {
                        Console.WriteLine($"Год: {record.Year}, Суммарная продолжительность: {record.TotalDuration}");
                    }
                }
            }
            CalculateTotalDurationForMonth(records);
        }
    }
}