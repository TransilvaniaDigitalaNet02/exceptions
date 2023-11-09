using System.Text;

namespace ExceptionsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Console.WriteLine("Starting Main");
            Function1();
            Console.WriteLine("Finished Main");
        }

        

        private static void PrintFileContents(string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                Console.WriteLine(text);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid path: must be a non-null string");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid path: must be a non-empty, non-whitespaces only string and must not containg invalid path characters");
            }
            catch (DirectoryNotFoundException dirNotFoundException)
            {
                Console.WriteLine($"Invalid directory path: {dirNotFoundException.Message}");
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine($"File was not found: {fileNotFoundException.FileName}");
            }
        }

        private static void Function1()
        {
            Console.WriteLine("Inside Function 1");
            Function2();
            Console.WriteLine("Finished Function 1");

            /*
            try
            {
                Console.WriteLine("Inside Function 1");
                Function2();
                
            }
            catch (Exception ex) when (ShouldCatch(ex))
            {
                throw new Exception($"Something went wrong when calling {nameof(Function2)}", ex);
            }
            finally
            {
                Console.WriteLine("Finished Function 1");
            }
            */
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

        private static bool ShouldCatch(Exception ex)
        {
            //StringBuilder exceptionBuilder = new StringBuilder();
            //exceptionBuilder.AppendLine("Catching an Exception inside Function 1");
            //exceptionBuilder.AppendLine(ex.Message);
            //exceptionBuilder.AppendLine(ex.StackTrace);
            //Console.WriteLine(exceptionBuilder.ToString());

            return true;
        }

        private static void LogException(Exception ex)
        {
            StringBuilder exceptionBuilder = new StringBuilder();
            LogException(ex, exceptionBuilder, 0);

            Console.WriteLine(exceptionBuilder.ToString());
        }

        private static void LogException(Exception ex, StringBuilder exceptionBuilder, int indentLevel)
        {
            string indent = new string(' ', 4 * indentLevel);
            exceptionBuilder.AppendLine(indent + "An error has occured:");
            exceptionBuilder.AppendLine(indent + ex.Message);
            exceptionBuilder.AppendLine(indent + ex.StackTrace);
            if (ex.InnerException is not null)
            {
                exceptionBuilder.AppendLine(indent + "Inner exception:");
                LogException(ex.InnerException, exceptionBuilder, indentLevel + 1);
            }
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            LogException((Exception)e.ExceptionObject);
            Environment.Exit(1);
        }
    }
}