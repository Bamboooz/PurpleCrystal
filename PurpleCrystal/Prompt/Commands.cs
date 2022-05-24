using System;
using Sys = Cosmos.System;
using static PurpleCrystal.System.Boot.boot;
using static PurpleCrystal.Utils.Tools.Shortcuts;
using static PurpleCrystal.Utils.Apps.calc;
using static PurpleCrystal.Utils.Filesystem.cat;
using static PurpleCrystal.Utils.Filesystem.cd;
using static PurpleCrystal.Utils.Filesystem.del;
using static PurpleCrystal.Utils.Filesystem.dir;
using static PurpleCrystal.Utils.Filesystem.edit;
using static PurpleCrystal.Utils.Filesystem.getfst;
using static PurpleCrystal.Utils.Filesystem.makedir;
using static PurpleCrystal.Utils.Filesystem.rmdir;
using static PurpleCrystal.Utils.Filesystem.touch;
using static PurpleCrystal.Utils.Filesystem.vol;

namespace PurpleCrystal.Prompt
{
    class Commands
    {

        public static String consoleInput;
        public static String username = "";

        public static void new_command()
        {

            user_text();

            consoleInput = Console.ReadLine();
            if (consoleInput.Contains("  "))
            {
                consoleInput = consoleInput.Replace("  ", " ");
            }

            if (consoleInput.ToLower() == "help")
            {
                Console.WriteLine("List Of Commands in PurpleCrystal operating system:");
                Console.WriteLine("- 'help' (to show list of commands)");
                Console.WriteLine("- 'shutdown' (to shutdown system)");
                Console.WriteLine("- 'reboot' (to reboot system)");
                Console.WriteLine("- 'clear' (to clear console)");
                Console.WriteLine("- 'vol' (to list volume)");
                Console.WriteLine("- 'getfst' (to get file system type)");
                Console.WriteLine("- 'dir' (to get file and folder list)");
                Console.WriteLine("- 'cd' (to change current directory)");
                Console.WriteLine("- 'touch' (to create a file)");
                Console.WriteLine("- 'edit' (to edit a file)");
                Console.WriteLine("- 'cat' (to display a text file)");
                Console.WriteLine("- 'del' (to delete a file)");
                Console.WriteLine("- 'mkdir' (to create new directory)");
                Console.WriteLine("- 'rmdir' (to remove a directoryw)");
                Console.WriteLine("- 'calc' opens calculator");
                Console.WriteLine("- 'echo' prints some text");
                Console.WriteLine("- 'time' (to display current date and time)");
                Console.WriteLine("- 'sysinfo' shows information about system.");
                Console.WriteLine("- 'oslogo' displays os logo.");
                Console.WriteLine("- 'beep' OS beeps.");
                new_command();
            }
            else if (consoleInput == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            else if (consoleInput == "reboot")
            {
                Sys.Power.Reboot();
            }
            else if (consoleInput == "clear")
            {
                Console.Clear();
                new_command();

            }
            else if (consoleInput == "vol")
            {
                volcommand();
                new_command();
            }
            else if (consoleInput == "getfst")
            {
                getfilesystemtype();
                new_command();
            }
            else if (consoleInput.Contains("dir") && !consoleInput.Contains("mkdir") && !consoleInput.Contains("rmdir") && !consoleInput.Contains("touch"))
            {
                dircommand();
                new_command();
            }
            else if (consoleInput.Contains("cd"))
            {
                cdcommand();
                new_command();
            }
            else if (consoleInput.Contains("touch"))
            {
                touchcommand();
                new_command();
            }
            else if (consoleInput.Contains("edit"))
            {
                editcommand();
                new_command();
            }
            else if (consoleInput.Contains("cat"))
            {
                catcommand();
                new_command();
            }
            else if (consoleInput.Contains("del"))
            {
                delcommand();
                new_command();
            }
            else if (consoleInput.Contains("mkdir") && !consoleInput.Contains("rmdir"))
            {
                mkdir();
                new_command();
            }
            else if (consoleInput.Contains("rmdir"))
            {
                removedir();
                new_command();
            }
            else if (consoleInput == "calc")
            {
                simplecalc();
            }
            else if (consoleInput.Contains("echo"))
            {
                Console.WriteLine(consoleInput.Replace("echo ", ""));
                new_command();
            }
            else if (consoleInput == "time")
            {
                Console.Write("Clock: ");
                DateTime now = DateTime.Now;
                Console.WriteLine(now);
                new_command();
            }
            else if (consoleInput == "sysinfo")
            {
                int Total = Convert.ToInt32(Cosmos.Core.CPU.GetAmountOfRAM());
                int Used = Convert.ToInt32(Cosmos.Core.CPU.GetEndOfKernel() + 1024) / 1048576;
                int Free = Used * 100 / Total;
                Console.WriteLine("Info About Your OS:");
                Console.WriteLine("OS Name: PurpleCrystal");
                Console.WriteLine("OS Version: PurpleCrystal: v.1.0");
                Console.WriteLine("OS Creator: @Bamboooz");
                Console.WriteLine("Memory Info:");
                Console.WriteLine("Total Memory: " + Total + " MB");
                Console.WriteLine("Used Memory: " + Used + " MB");
                Console.WriteLine("Free Memory: " + Free + " MB");
                new_command();
            }
            else if (consoleInput == "oslogo")
            {
                printOSLogo();
                new_command();
            }
            else if (consoleInput == "beep")
            {
                Console.WriteLine("beep");
                Sys.PCSpeaker.Beep();
                new_command();
            }
            else
            {
                command_not_found();
                new_command();
            }

        }

        public static void command_not_found()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Command not found!");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
