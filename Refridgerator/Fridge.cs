﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refridgerator
{
    class Fridge
    {
        public List<Box> Boxes;

        public Fridge(int boxesNumber)
        {
            Boxes = new List<Box>();
            for (int i = 0; i < boxesNumber; i++ )
            {
                Boxes.Add(new Box());
            }
        }

        public void OpenBox(int boxNumber)
        {
            Boxes.ElementAt(boxNumber).Open();
        }


        public void CloseBox(int boxNumber)
        {
            Boxes.ElementAt(boxNumber).Close();
        }

        public void PutInBox(int boxNumber, Article article)
        {
            Boxes.ElementAt(boxNumber).Add(article);
        }

        public IEnumerable<Article> getAllArticleList()
        {
            for (int i = 0; i < Boxes.Count; i++)
            {
                var articlesInBox = getArticleListInBox(i);
                foreach (var article in articlesInBox)
                {
                    yield return article;
                }
            }
        }

        public List<Article> getArticleListInBox(int boxNumber)
        {            
            return Boxes.ElementAt(boxNumber).GetArticles();
        }

        public Article GetFromBox(int boxNumber, string barcode) 
        {

            Article article = Boxes.ElementAt(boxNumber).Remove(barcode);
            return article;
        }


        public void SetTemperature(int boxNumber, int minTemperature, int maxTemperature) {
            Boxes.ElementAt(boxNumber).SetTemperature(minTemperature, maxTemperature);
        }

        public void DefrostBox(int boxNumber) {
            Boxes.ElementAt(boxNumber).Defrost();
        }
    }
}
