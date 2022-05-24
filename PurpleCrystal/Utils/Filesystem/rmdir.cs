using System;
using static PurpleCrystal.Prompt.Commands;
using System.IO;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class rmdir
    {

        public static void removedir()
        {

            String removedDir = consoleInput;
            removedDir = removedDir.Replace("rmdir ", "");

            try
            {
                Directory.Delete(removedDir);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }

}