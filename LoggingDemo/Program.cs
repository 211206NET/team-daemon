using Serilog;

bool exit = false;
do 
{
    Console.WriteLine("Hello! What aspect of Serilog do you want to try");
    Console.WriteLine("[1] Console Logging");
    Console.WriteLine("[2] Debugging/File Logging");
    Console.WriteLine("[x] Exit");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Console Logging");
            Console.WriteLine("Please write a message");
            string text = Console.ReadLine() ?? "";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Information("This is an example of recording logs");
            Log.Information("{text}", text);
            
        break;
        case "2":
            Console.WriteLine("Debugging/File Logging");
            Console.WriteLine("Check your folder");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"C:\Users\cynth\OneDrive\Documents\Revature\DebugFile.log")
                .CreateLogger();
                try
                {
                    int c = 3; int d = 0;
                    Log.Information("Dividing {c} by {d}", c, d);
                    int e = c / d;
                }
                catch(Exception ex)
                {
                    Log.Error(ex, "OOPS! There's an error");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
        break;
        case "x":
            exit = true;
        break;
    }
}while(!exit);