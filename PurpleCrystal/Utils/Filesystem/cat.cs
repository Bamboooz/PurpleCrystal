using System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;
using System.Text;
using static PurpleCrystal.Prompt.Commands;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class cat
    {

        public static void catcommand()
        {

            String fileDir = consoleInput;
            fileDir = fileDir.Replace("cat ", "");

            if (fileDir.Contains("mkdir") || fileDir.Contains("touch"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File Name Cannot Contain Letter Arrays:\nvol', 'getfst', 'cd', 'dir', 'mkdir',\nrmdir', 'touch', 'del', 'edit', 'cat'.");
                Console.ForegroundColor = ConsoleColor.White;
                new_command();

            } else
            {
                try
                {
                    var file = VFSManager.GetFile(fileDir);
                    var file_stream = file.GetFileStream();

                    if (file_stream.CanRead)
                    {
                        byte[] text_to_read = new byte[file_stream.Length];
                        file_stream.Read(text_to_read, 0, (int)file_stream.Length);
                        Console.WriteLine(Encoding.Default.GetString(text_to_read));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }

        }

    }

}