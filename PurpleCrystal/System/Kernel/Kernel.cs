using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using static PurpleCrystal.System.Boot.boot;

namespace PurpleCrystal
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        protected override void Run()
        {
            bootup();
        }
    }
}
