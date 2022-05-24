using System;
using Cosmos.System.FileSystem.VFS;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class vol {

        public static void volcommand() {

            long available_space = VFSManager.GetAvailableFreeSpace("0:/");
            Console.WriteLine("Available Free Space: " + available_space);

        }
     
    }

}