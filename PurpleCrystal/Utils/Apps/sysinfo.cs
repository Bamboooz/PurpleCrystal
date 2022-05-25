using System;

namespace PurpleCrystal.Utils.Apps
{
    class sysinfo
    {

        public static void run_sysinfo()
        {
            int Total = Convert.ToInt32(Cosmos.Core.CPU.GetAmountOfRAM());
            int Used = Convert.ToInt32(Cosmos.Core.CPU.GetEndOfKernel() + 1024) / 1048576;
            int Free = Used * 100 / Total;
            Console.WriteLine("Info About Your OS:");
            Console.WriteLine("OS Name: PurpleCrystal");
            Console.WriteLine("OS Version: PurpleCrystal: v.1.0");
            Console.WriteLine("OS Creator: @Bamboooz");
            Console.WriteLine("Memory Info:");
            Console.WriteLine("Total Memory: " + Total + " MB");
            Console.WriteLine("Used Memory: " + Used + " MB");
            Console.WriteLine("Free Memory: " + Free + " MB");
        }

    }
}
