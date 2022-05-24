using System;
using static PurpleCrystal.Prompt.Commands;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class cd
    {

        public static string dir = "";
        public static string dir1 = "";

        public static void handlecd()
        {
            if (dir1.Equals(""))
            {
                dir = @"0:\";
            } else
            {
                dir = dir1;
            }
            
        }

        public static void cdcommand()
        {
            if (!consoleInput.Contains("mkdir") && !consoleInput.Contains("touch"))
            {
                String reader = consoleInput;
                dir = @"0:\";

                if (reader.Contains("cd "))
                {
                    string[] result = reader.Split("cd ");
                    dir1 = result[0];
                }
                else
                {
                    dir = @"0:\";
                }

            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File Name Cannot Contain Letter Arrays:\nvol', 'getfst', 'cd', 'dir', 'mkdir',\nrmdir', 'touch', 'del', 'edit', 'cat'.");
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }

        }

    }

}