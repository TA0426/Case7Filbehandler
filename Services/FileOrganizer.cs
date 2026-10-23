// FIL: FileOrganizer.cs -> Selve filbehandlingsklassen
using System;

namespace FileOrganizerCLI.Services
{
    public class FileOrganizer
    {
        public void Run(string path, int choice, bool dryRun)
        {

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory not found.");
                return;
            }

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var info = new FileInfo(file);
                string folderName;

                switch (choice)
                {
                    case 1:

                        folderName = Path.GetExtension(file).Trim('.').ToLowerInvariant();

                        if (string.IsNullOrEmpty(folderName))
                            folderName = "uten-filtype";

                        break;
                    case 2:
                        folderName = info.LastWriteTime.ToString("yyyy-MM");
                        break;
                    case 3:
                        long oneMb = 1024L * 1024;
                        long oneHundredMb = 100L * oneMb;
                        long oneThousandMb = 1000L * oneMb;

                        if (info.Length < oneMb)
                            folderName = "under-1-MB";
                        else if (info.Length < oneHundredMb)
                            folderName = "1-100-MB";
                        else if (info.Length <= oneThousandMb)
                            folderName = "100-1000-MB";
                        else
                            folderName = "over-1000-MB";

                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                string targetDir = Path.Combine(path, folderName);
                string targetPath = Path.Combine(targetDir, Path.GetFileName(file));

                string action = dryRun
                    ? $"DRY RUN: Would move {file} -> {targetPath}"
                    : $"Moved {file} -> {targetPath}";

                Console.WriteLine(action);
                Log(action);

                if (!dryRun)
                {
                    Directory.CreateDirectory(targetDir);
                    File.Move(file, targetPath, true);
                }

            }

            Console.WriteLine("Done!");

        }
        private static void Log(string message)
        {
            string logPath = Path.Combine(
                AppContext.BaseDirectory,
                "organizer.log");

            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}{Environment.NewLine}";
            File.AppendAllText(logPath, entry);
        }
    }
}
