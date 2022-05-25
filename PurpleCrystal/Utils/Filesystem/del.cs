using System;
using Cosmos.System.FileSystem.VFS;
using static PurpleCrystal.Prompt.Commands;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class del
    {
        public static string delName;

        public static void delcommand()
        {

            delName = consoleInput;
            delName = delName.Replace("del ", "");

            try
            {
                VFSManager.GetFile(delName);
                VFSManager.DeleteFile(delName);
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