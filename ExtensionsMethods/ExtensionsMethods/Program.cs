namespace ExtensionsMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string s=Console.ReadLine();

            Console.WriteLine($"Количество слов: {s.CountWords()} ");

            var rnd=new Random();
            for(var i=0; i<100; i++)
            {
                Console.Write($"{rnd.NextDouble():F5} ");
            }

            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                Console.Write($"{rand.FlatDistribution(-1,2):F5} ");
            }

            Console.ReadKey();
        }
    }
}
