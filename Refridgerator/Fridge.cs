using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refridgerator
{
    class Fridge
    {
        public List<Box> Boxes = new List<Box>();

        public void OpenBox(int boxNumber)
        {
        }

        private void alarm(string message)
        {
        }

        public void CloseBox(int boxNumber)
        {
        }

        public void PutInBox(int boxNumber, Article article) {}

        public Article GetFromBox(int boxNumber, string barcode) 
        { throw new NotImplementedException(); }

        public IEnumerable<Article> GetList(int boxNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void SetMaxTemperature(int boxNumber, int temperature) { }
        public void SetMinTemperature(int boxNumber, int temperature) { }

        public void DefrostFridge() { }

        private bool allBoxesEmpty() { throw new NotImplementedException(); }

        private void defrost() { }
    }
}
