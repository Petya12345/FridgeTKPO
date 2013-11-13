using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Refridgerator
{
    class Box
    {
        public List<Article> Articles = new List<Article>();
        public List<string> Barcodes = new List<string>();
        public float minTemperature { get; set; }
        public float maxTemperature { get; set; }
        System.Timers.Timer boxOpenTimer;
        System.Timers.Timer checkingTimer;
        private float currentTemperature { get; set; }
        //private Engine engine;

        public Box()
        {
            boxOpenTimer = new System.Timers.Timer();
            boxOpenTimer.Elapsed += new ElapsedEventHandler(OnOpenedDoor);
            boxOpenTimer.Interval = 120 * 1000; //CONST


            System.Timers.Timer temperatureUp = new System.Timers.Timer();
            temperatureUp.Elapsed += new ElapsedEventHandler(OnTemperatureUp);
            temperatureUp.Interval = 2 * 1000;//CONST
            temperatureUp.Start();


            checkingTimer = new System.Timers.Timer();
            checkingTimer.Elapsed += new ElapsedEventHandler(OnCheck);
            checkingTimer.Interval = 10 * 1000;//CONST


            //engine = new Engine(this);


            minTemperature = -10;
            maxTemperature = -1;
            currentTemperature = 5;
        }
        private void OnCheck(object source, ElapsedEventArgs e)
        {
            if (currentTemperature > maxTemperature)
            {
                //engine.startFreezung();
            }
            else if (currentTemperature < minTemperature)
            {
                //engine.stopFreezung();
            }
        }

        private void OnOpenedDoor(object source, ElapsedEventArgs e)
        {
            alarm("Дверца камеры открыта более двух минут!");
        }

        private void OnTemperatureUp(object source, ElapsedEventArgs e)
        {
            currentTemperature += (float)0.8;
        }

        public List<string> getArticleTitles()
        {
            List<string> list = new List<string>();
            foreach (Article a in Articles)
            {
                list.Add(a.Title);
            }
            return null;
        }

        public void add(Article article)
        {
            Barcodes.Add(article.Barcode);
            Articles.Add(article);
        }

        public Article remove(string barcode)
        {

            return null;
        }

        public void open()
        {
            boxOpenTimer.Start();
        }

        public void close()
        {
            boxOpenTimer.Stop();
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

        public void Defrost()
        {
            checkingTimer.Stop();
        }

        private void alarm(string message) { }

        private bool isBoxEmpty() { throw new NotImplementedException(); }
    }
}
