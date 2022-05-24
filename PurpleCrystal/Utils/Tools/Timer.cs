using Cosmos.HAL;

namespace PurpleCrystal.Utils.Tools
{
    class Timer
    {
        public static void Sleep(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;

            if (StartSec + secNum > 59)
                EndSec = 0;
            else
                EndSec = StartSec + secNum;

            // Loop round
            while (RTC.Second != EndSec) ;
        }

    }
}
