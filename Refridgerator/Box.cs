using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refridgerator
{
    class Box
    {
        public List<Article> Articles = new List<Article>();
        public int minTemperature { get; set; }
        public int maxTemperature { get; set; }

        public void StartMonitoring() { }

        private int howLongOpen()
        {
            throw new NotImplementedException();
        }

        private int getTemperature()
        {
            throw new NotImplementedException();
        }

        private void turnOnFan()
        {
            throw new NotImplementedException();
        }

        private void turnOffFan()
        {
            throw new NotImplementedException();
        }
    }
}
