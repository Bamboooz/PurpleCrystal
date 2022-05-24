using System;
using Cosmos.System.FileSystem.VFS;

namespace PurpleCrystal.Utils.Filesystem
{
    public static class getfst {

        public static void getfilesystemtype() {

            string fs_type = VFSManager.GetFileSystemType("0:/");
            Console.WriteLine("File System Type: " + fs_type);

        }
     
    }

}