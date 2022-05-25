using System;
using static PurpleCrystal.Prompt.Commands;
using System.IO;
using Cosmos.System.FileSystem.VFS;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class rmdir
    {

        public static void removedir()
        {

            String removedDir = consoleInput;
            removedDir = removedDir.Replace("rmdir ", "");

            try
            {
                VFSManager.GetDirectory(removedDir);
                Directory.Delete(removedDir);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Cannot remove directory, because it doesn't exist.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

    }

}