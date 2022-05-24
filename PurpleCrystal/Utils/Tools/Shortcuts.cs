using System;
using System.Text;
using Sys = Cosmos.System;

namespace PurpleCrystal.Utils.Tools
{
    class Shortcuts
    {

        public static String username = "";

        public static void user_text()
        {
            try
            {
                var file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\PurpleCrystal\System\User\user.txt");
                var file_stream = file.GetFileStream();

                if (file_stream.CanRead)
                {
                    byte[] text_to_read = new byte[file_stream.Length];
                    file_stream.Read(text_to_read, 0, (int)file_stream.Length);
                    username = Encoding.Default.GetString(text_to_read);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(username);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@crystal");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
