using System;
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
            Boxes.ElementAt(boxNumber).open();
        }


        public void CloseBox(int boxNumber)
        {
            Boxes.ElementAt(boxNumber).close();
        }

        public void PutInBox(int boxNumber, Article article)
        {
            Boxes.ElementAt(boxNumber).add(article);
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
            return Boxes.ElementAt(boxNumber).getArticles();
        }

        public Article GetFromBox(int boxNumber, string barcode) 
        {

            Article article = Boxes.ElementAt(boxNumber).remove(barcode);
            throw new NotImplementedException(); 
        }


        public void SetTemperature(int boxNumber, int minTemperature, int maxTemperature) { }

        public void DefrostBox(int boxNumber) {
            Boxes.ElementAt(boxNumber).Defrost();
        }
    }
}
