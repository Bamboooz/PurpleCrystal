using System;
using Cosmos.System.FileSystem.VFS;
using static PurpleCrystal.Prompt.Commands;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class makedir
    {

        public static void mkdir()
        {

            String newDir = consoleInput;
            newDir = newDir.Replace("mkdir ", "");

            if (!newDir.Contains("vol") && !(newDir.Contains("getfst")) && !newDir.Contains("cd") && !(newDir.Contains("dir")) && !newDir.Contains("mkdir") && !newDir.Contains("rmdir") && !newDir.Contains("touch") && !newDir.Contains("del") && !newDir.Contains("edit") && !newDir.Contains("cat"))
            {
                try
                {
                    VFSManager.GetDirectory(newDir);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Cannot create directory, because it already exists.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception)
                {
                    VFSManager.CreateDirectory(newDir);
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory Name Cannot Contain Letter Arrays:\nvol', 'getfst', 'cd', 'dir', 'mkdir',\nrmdir', 'touch', 'del', 'edit', 'cat'.");
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }


        }

    }

}