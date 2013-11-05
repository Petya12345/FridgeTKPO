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

        public Engine(ref Box boxRef)
        {
            box = boxRef;
            freezingTimer.Elapsed += new ElapsedEventHandler(lowerTemperature);
            freezingTimer.Interval = 10 * 1000;//CONST
        }

        private void lowerTemperature(object source, ElapsedEventArgs e)
        {
            //box.currentTemperature--; 
        }

        public void startFreezng()
        {
            //timer.start();
        }

        public void stopFreezung()
        {
            //timerStop();
        }

    }
}
