using System;
using Sys = Cosmos.System;
using static PurpleCrystal.Utils.Tools.Timer;
using static PurpleCrystal.Prompt.Commands;
using System.Text;
using System.IO;

namespace PurpleCrystal.System.Boot
{
    class boot
    {

        public static string user_pass = "";
        public static void bootup()
        {
            // bootbar that has no use cause why not
            bootBarProgress("     [                                                            ]");
            bootBarProgress("     [==========                                                  ]");
            bootBarProgress("     [====================                                        ]");
            bootBarProgress("     [==============================                              ]");
            bootBarProgress("     [========================================                    ]");
            bootBarProgress("     [==================================================          ]");
            bootBarProgress("     [============================================================]");
            Sleep(2);
            is_oobe_done();
        }

        public static void is_oobe_done()
        {
            try
            {
                // checking if all system files exist - if yes oobe is done
                Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\oobe\oobe_done.txt");
                Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\User\user.txt");
                Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\User\pass.txt");
                run();
            }
            catch (Exception)
            {
                // if file does not exist - start oobe
                oobe();
            }
        }

        public static void oobe()
        {
            try
            {
                // creating needed system files
                Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\PurpleCrystal\System\oobe");
                Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\PurpleCrystal\System\User");
                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\PurpleCrystal\System\oobe\oobe_done.txt");
                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\PurpleCrystal\System\User\user.txt");
                Sys.FileSystem.VFS.VFSManager.CreateFile(@"0:\PurpleCrystal\System\User\pass.txt");

                try
                {
                    // removing base fat32 cosmos filesystem files that are useless
                    Sys.FileSystem.VFS.VFSManager.DeleteFile(@"0:\Kudzu.txt");
                    Sys.FileSystem.VFS.VFSManager.DeleteFile(@"0:\Root.txt");
                    Sys.FileSystem.VFS.VFSManager.DeleteFile(@"0:\TEST\DirInTest\Readme.txt");
                    Directory.Delete(@"0:\TEST\DirInTest");
                    Directory.Delete(@"0:\TEST");
                    Directory.Delete(@"0:\Dir Testing");
                }
                catch (Exception)
                {
                    oobe_error();
                }

            }
            catch (Exception)
            {
                oobe_error();
            }

            // PurpleCrystal setup start

            Console.Clear();
            printOSLogo();
            Console.WriteLine("PurpleCrystal setup is starting....");
            Sleep(4);

            // setting your username
            Console.Clear();
            Console.WriteLine("Please enter your new username:\n");
            var username = Console.ReadLine();

            try
            {
                // writing to a system file that contains username
                var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\User\user.txt");
                var file_stream = file.GetFileStream();

                if (file_stream.CanWrite)
                {
                    byte[] text_to_write = Encoding.ASCII.GetBytes("");
                    text_to_write = Encoding.ASCII.GetBytes(username);
                    file_stream.Write(text_to_write, 0, text_to_write.Length);
                }

            }
            catch (Exception)
            {
                oobe_error();
            }

            Console.Clear();
            printOSLogo();

            // setting password for your user
            Console.Clear();
            Console.WriteLine("Please enter your new password:\n");
            var password = Console.ReadLine();

            try
            {
                // writing to a system file that contains user password
                var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\User\pass.txt");
                var file_stream = file.GetFileStream();

                if (file_stream.CanWrite)
                {
                    byte[] text_to_write = Encoding.ASCII.GetBytes("");
                    text_to_write = Encoding.ASCII.GetBytes(password);
                    file_stream.Write(text_to_write, 0, text_to_write.Length);
                }
            }
            catch (Exception)
            {
                oobe_error();
            }

            Console.Clear();
            Console.WriteLine("Please wait, setup is almost done...");
            Sleep(4);
            run();

        }

        public static void oobe_error()
        {
            // error message if oobe had an error
            Console.Clear();
            Console.WriteLine("There was an error during PurpleCrystal Operating System setup.");
            Console.WriteLine("Your operating system will be restarted in 5 seconds...");
            Sleep(5);
            Sys.Power.Reboot();
        }

        public static void run()
        {
            // message on succesfull operating system run
            Console.WriteLine("Please enter your password:");
            var entered_pass = Console.ReadLine();

            try
            {
                // getting password from system file

                var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\User\pass.txt");
                var file_stream = file.GetFileStream();

                if (file_stream.CanRead)
                {
                    byte[] text_to_read = new byte[file_stream.Length];
                    file_stream.Read(text_to_read, 0, (int)file_stream.Length);
                    user_pass = Encoding.Default.GetString(text_to_read);
                }

                // if entered password equals correct password, run os, if not, print error msg

                if (entered_pass == user_pass)
                {
                    printOSLogo();
                    Console.WriteLine("");
                    Console.WriteLine("PurpleCrystal booted up succesfully.");
                    Console.WriteLine("PurpleCrystal coded by Bamboooz in C# using COSMOS.");
                    Console.WriteLine("Enter 'help' to get list of commands.");
                    Console.WriteLine("");
                    new_command();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong password.");
                    Console.ForegroundColor = ConsoleColor.White;
                    run();
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

        }

        public static void bootBarProgress(String fooBar)
        {
            // shortened bootbar drawing method
            printOSLogo();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                PurpleCrystal Is Booting Up, Please Wait");
            Console.WriteLine(" " + fooBar);
            Sleep(1);
            Console.Clear();

        }

        public static void printOSLogo()
        {
            // function to print os logo cause purplecrystal uses a lot of this function
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"                                    /\");
            Console.WriteLine(@"                                   / /\");
            Console.WriteLine(@"                                  /\/  \");
            Console.WriteLine(@"                                 /  \   \");
            Console.WriteLine(@"                                /\   \  /\");
            Console.WriteLine(@"                               /  \   \/  \");
            Console.WriteLine(@"                               \  /\  /\  /");
            Console.WriteLine(@"                                \/  \/  \/");
            Console.WriteLine(@"                                 \  /   /");
            Console.WriteLine(@"                                  \/   /");
            Console.WriteLine(@"                                   \  /");
            Console.WriteLine(@"                                    \/");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
