using System;
using Cosmos.System.FileSystem.VFS;
using static PurpleCrystal.Prompt.Commands;
using static PurpleCrystal.Utils.Filesystem.cd;
namespace PurpleCrystal.Utils.Filesystem
{
    public static class dir {

        public static string searchdir;

        public static void dircommand() {

            String dirValue = consoleInput;

            if (dirValue.Contains("dir "))
            {
                searchdir = dirValue.Replace("dir ", "");
            }
            else
            {
                handlecd();
                searchdir = cd.dir;
            }

            try
            {
                VFSManager.GetDirectory(searchdir);

                var directory_list = VFSManager.GetDirectoryListing(searchdir);

                foreach (var directoryEntry in directory_list)
                {
                    Console.WriteLine(directoryEntry.mName);
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Cannot write to this file, because it doesn't exist.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
     
    }

}