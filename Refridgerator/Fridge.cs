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

        public List<string> getAllArticleList()
        {
            List<string> articles = new List<string>();

            foreach (Box b in Boxes) //index?
            {
                foreach (string a in getArticleListInBox(Boxes.IndexOf(b)))
                {
                    articles.Add(a);
                }
            }

            return articles;
        }

        public List<string> getArticleListInBox(int boxNumber)
        {            
            return Boxes.ElementAt(boxNumber).getArticleTitles();
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
