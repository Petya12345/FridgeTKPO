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
            box = boxRef;
            freezingTimer.Elapsed += new ElapsedEventHandler(lowerTemperature);
            freezingTimer.Interval = 6 * 1000;//CONST
        }

        private void lowerTemperature(object source, ElapsedEventArgs e)
        {
            box.currentTemperature--; 
        }

        public void startFreezung()
        {
            freezingTimer.Stop();
        }

        public void stopFreezung()
        {
            freezingTimer.Start();
        }

    }
}
