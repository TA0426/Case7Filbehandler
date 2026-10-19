// FIL: Program.cs -> hovedpunkt for programmet
using FileOrganizerCLI.Services;

namespace FileOrganizerCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to File Organizer CLI");

            var organizer = new FileOrganizer();
            // Windows File System
            organizer.Run(@"C:\Users\You\Downloads");
            // Unix File Systems
            organizer.Run(@"/home/you/Downloads");
            //  MacOS File Systems
            organizer.Run(@"User-MacBook%/");
        }
    }
}