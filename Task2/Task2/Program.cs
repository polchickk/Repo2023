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
                new Record { ClientID = 3, Year = 2021, Month = 2, Duration = 15 },
                new Record { ClientID = 4, Year = 2020, Month = 2, Duration = 25 },
                new Record { ClientID = 15, Year = 2020, Month = 1, Duration = 30 },
                new Record { ClientID = 22, Year = 2020, Month = 2, Duration = 40 },
                new Record { ClientID = 13, Year = 2022, Month = 2, Duration = 35 },
                new Record { ClientID = 2, Year = 2022, Month = 2, Duration = 45 },
                new Record { ClientID = 1, Year = 2022, Month = 2, Duration = 45 }
            };

             static void PrintClientCountByMonth(List<Record> records)
            {
                var groupedRecords = records.GroupBy(r => new { r.Year, r.Month });
                var result = groupedRecords.Select(g => new {
                    g.Key.Year,
                    g.Key.Month,
                    Count = g.Select(r => r.ClientID).Distinct().Count()
                });
                var sortedResult = result.OrderByDescending(r => r.Year).ThenBy(r => r.Month);
                foreach (var r in sortedResult)
                {
                    Console.WriteLine($"{r.Year} {r.Month} {r.Count}");
                }
            }
            PrintClientCountByMonth(records);
        }
        
    }
}