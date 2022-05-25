using System;
using Cosmos.System.FileSystem.VFS;
using static PurpleCrystal.Prompt.Commands;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class touch
    {
        public static string fileName;

        public static void touchcommand()
        {

            fileName = consoleInput;
            fileName = fileName.Replace("touch ", "");

            if (!fileName.Contains("vol") && !fileName.Contains("getfst") && !(fileName.Contains("cd")) && !fileName.Contains("dir") && !fileName.Contains("mkdir") && !fileName.Contains("rmdir") && !fileName.Contains("touch") && !fileName.Contains("del") && !fileName.Contains("edit") && !fileName.Contains("cat"))
            {
                try
                {
                    VFSManager.CreateFile(fileName);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Cannot create to this file, because its directory doesn't exist or file already exists.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File Name Cannot Contain Letter Arrays:\nvol', 'getfst', 'cd', 'dir', 'mkdir',\nrmdir', 'touch', 'del', 'edit', 'cat'.");
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }


        }

    }

}