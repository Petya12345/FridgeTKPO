﻿using System;
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
        public int minTemperature { get; set; }
        public int maxTemperature { get; set; }
        System.Timers.Timer boxOpenTimer;
        System.Timers.Timer checkingTimer;
        public int currentTemperature { get; set; }
        private Engine engine;

        public Box()
        {
            const int CHECK_OPENED_DOOR = 120;
            const int NORMAL_TEMP_INCREASES = 5;
            const int CHECK_TEMP = 10;


            boxOpenTimer = new System.Timers.Timer();
            boxOpenTimer.Elapsed += new ElapsedEventHandler(onOpenedDoor);
            boxOpenTimer.Interval = CHECK_OPENED_DOOR * 1000; //CONST


            System.Timers.Timer temperatureUp = new System.Timers.Timer();
            temperatureUp.Elapsed += new ElapsedEventHandler(onTemperatureUp);
            temperatureUp.Interval = NORMAL_TEMP_INCREASES * 1000;//CONST
            temperatureUp.Start();


            checkingTimer = new System.Timers.Timer();
            checkingTimer.Elapsed += new ElapsedEventHandler(onCheck);
            checkingTimer.Interval = CHECK_TEMP * 1000;//CONST
            checkingTimer.Start();


            engine = new Engine(this);


            minTemperature = -20;
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
            currentTemperature += 1;
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
                    Articles.Remove(a);
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
            return currentTemperature;
        }


        public void Defrost()
        {
            if (isBoxEmpty())
                checkingTimer.Stop();
            else
                alarm("Сначала выньте все продукты из холодильника!");
        }


        public void SetTemperature(int min, int max)
        {
            this.minTemperature = min;
            this.maxTemperature = max;
        }

        private void alarm(string message) 
        {
            MessageBox.Show(message);
        }

        private bool isBoxEmpty() 
        {
            if (this.GetArticles().Count() > 0)
                return false;

            return true;
        }
    }
}
