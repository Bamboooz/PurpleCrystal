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
                VFSManager.DeleteFile(delName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }

}