using System;
using Sys = Cosmos.System;
using System.Text;
using static PurpleCrystal.Prompt.Commands;
using Cosmos.System.FileSystem.VFS;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class edit
    {
        public static string fileDir;

        public static void editcommand()
        {

            fileDir = consoleInput;
            fileDir = fileDir.Replace("edit ", "");

            try
            {
                VFSManager.GetFile(fileDir);

                var file = VFSManager.GetFile(fileDir);
                var file_stream = file.GetFileStream();
           
                if (file_stream.CanWrite)
                {
                    Console.WriteLine("Enter Text That You Want To Add To: " + fileDir);
                    byte[] text_to_write = Encoding.ASCII.GetBytes("");
                    text_to_write = Encoding.ASCII.GetBytes(Console.ReadLine());
                    file_stream.Write(text_to_write, 0, text_to_write.Length);
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Cannot edit file, because it doesn't exist.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

    }

}