using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

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
        public float currentTemperature { get; set; }
        private Engine engine;

        public Box()
        {
            boxOpenTimer = new System.Timers.Timer();
            boxOpenTimer.Elapsed += new ElapsedEventHandler(onOpenedDoor);
            boxOpenTimer.Interval = 6 * 1000; //CONST


            System.Timers.Timer temperatureUp = new System.Timers.Timer();
            temperatureUp.Elapsed += new ElapsedEventHandler(onTemperatureUp);
            temperatureUp.Interval = 2 * 1000;//CONST
            temperatureUp.Start();


            checkingTimer = new System.Timers.Timer();
            checkingTimer.Elapsed += new ElapsedEventHandler(onCheck);
            checkingTimer.Interval = 10 * 1000;//CONST


            engine = new Engine(this);


            minTemperature = -10;
            maxTemperature = -1;
            currentTemperature = 5;

        }
        private void onCheck(object source, ElapsedEventArgs e)
        {
            if (currentTemperature > maxTemperature)
            {
                engine.startFreezung();
            }
            else if (currentTemperature < minTemperature)
            {
                engine.stopFreezung();
            }
        }

        private void onOpenedDoor(object source, ElapsedEventArgs e)
        {
            alarm("Дверца камеры открыта более двух минут!");
        }

        private void onTemperatureUp(object source, ElapsedEventArgs e)
        {
            currentTemperature += (float)0.8;
        }

        public List<Article> GetArticles()
        {
            return Articles;
        }

        public void Add(Article article)
        {
            Barcodes.Add(article.Barcode);
            Articles.Add(article);
        }

        public Article Remove(string barcode)
        {
            foreach (Article a in Articles)
            {
                if (a.Barcode == barcode)
                {
                    return a;
                }
            }

            return null;
        }

        public void Open()
        {
            boxOpenTimer.Start();
        }

        public void Close()
        {
            boxOpenTimer.Stop();
        }

        private int getTemperature()
        {
            throw new NotImplementedException();
        }


        public void Defrost()
        {
            checkingTimer.Stop();
        }

        private void alarm(string message) 
        {
            MessageBox.Show(message);
        }

        private bool isBoxEmpty() { throw new NotImplementedException(); }
    }
}
