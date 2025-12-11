class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Extension File ===");
        Console.WriteLine("Enter an extension file ");
        Console.WriteLine("Type 'exit' to exit");

        while (true)
        {
            Console.Write("Enter extension: ");
            string input = Console.ReadLine()?.Trim() ?? "";

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            // Ensure extension starts with a dot
            if (!input.StartsWith("."))
                input = "." + input;

            // Search dictionary in the other file
            if (FileExtension.Extensions.TryGetValue(input, out string description))
            {
                Console.WriteLine($"Extension '{input}': {description}\n");
            }
            else
            {
                Console.WriteLine($"Sorry, '{input}' is not recognized.\n");
            }
        }
    }
}
