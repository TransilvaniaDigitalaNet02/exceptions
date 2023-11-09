using System.Text;

namespace ExceptionsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Main");
            Function1();
            Console.WriteLine("Finished Main");
        }

        private static void Function1()
        {
            try
            {
                Console.WriteLine("Inside Function 1");
                Function2();
                Console.WriteLine("Finished Function 1");
            }
            catch (Exception ex)
            {
                StringBuilder exceptionBuilder = new StringBuilder();
                exceptionBuilder.AppendLine("Catching an Exception inside Function 1");
                exceptionBuilder.AppendLine(ex.Message);
                exceptionBuilder.AppendLine(ex.StackTrace);
                Console.WriteLine(exceptionBuilder.ToString());
            }
        }

        private static void Function2()
        {
            Console.WriteLine("Inside Function 2");
            Function3();
            Console.WriteLine("Finished Function 2");
        }

        private static void Function3()
        {
            Console.WriteLine("Inside Function 3");
            int number = 100, divisor = 0;
            int result = number / divisor;
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("Finished Function 3");
        }
    }
}