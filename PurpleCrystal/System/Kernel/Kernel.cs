using System;
using Cosmos.System.FileSystem.VFS;
using Sys = Cosmos.System;
using static PurpleCrystal.System.Boot.boot;
using System.IO;

namespace PurpleCrystal
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
            VFSManager.RegisterVFS(fs);
        }

        protected override void Run()
        {
            bootup();
        }
    }
}
