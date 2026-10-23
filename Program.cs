using FileOrganizerCLI.Services;

namespace FileOrganizerCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to File Organizer CLI");
                Console.WriteLine("Choose the following way to sort files:");
                Console.WriteLine("1. By type");
                Console.WriteLine("2. By date edited");
                Console.WriteLine("3. By size");
                Console.WriteLine("0. Exit");

                if (!int.TryParse(Console.ReadLine(), out var choice))
                {
                    Console.WriteLine("Please enter 1, 2, 3, or 0.");
                    continue;
                }

                if (choice == 0)
                    return;

                if (choice is < 1 or > 3)
                {
                    Console.WriteLine("Please choose 1, 2, 3, or 0.");
                    continue;
                }

                Console.WriteLine("Enter catalog path");
                var path = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine("Please enter a valid catalog path");
                    continue;
                }

                Console.WriteLine("Dry run? (y/n)");
                bool dryRun = Console.ReadLine()?.Trim().Equals(
                    "y",
                    StringComparison.OrdinalIgnoreCase) == true;

                var organizer = new FileOrganizer();
                organizer.Run(path, choice, dryRun);
            }
        }
    }
}
