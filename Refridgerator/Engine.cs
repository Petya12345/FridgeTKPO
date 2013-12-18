using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Refridgerator
{
    class Engine
    {
        private System.Timers.Timer freezingTimer = new System.Timers.Timer();
        private Box box;

        public Engine(Box boxRef)
        {
            const int LOWER_TEMP = 5;

            box = boxRef;
            freezingTimer.Elapsed += new ElapsedEventHandler(lowerTemperature);
            freezingTimer.Interval = LOWER_TEMP * 1000;//CONST
        }

        private void lowerTemperature(object source, ElapsedEventArgs e)
        {
            box.currentTemperature-=5; 
        }

        public void startFreezung()
        {
            freezingTimer.Start();
        }

        public void stopFreezung()
        {
            freezingTimer.Stop();
        }

    }
}
