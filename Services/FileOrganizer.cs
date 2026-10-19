// FIL: FileOrganizer.cs -> Selve filbehandlingsklassen
namespace FileOrganizerCLI.Services
{
    public class FileOrganizer
    {
        public void Run(string path)
        {
            Console.WriteLine($"Organizing files in: {path}");

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory not found.");
                return;
            }

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                string ext = Path.GetExtension(file).Trim('.').ToLower();
                string targetDir = Path.Combine(path, ext);

                Directory.CreateDirectory(targetDir);
                File.Move(file, Path.Combine(targetDir, Path.GetFileName(file)), true);
            }

            Console.WriteLine("Done!");
        }
    }
}