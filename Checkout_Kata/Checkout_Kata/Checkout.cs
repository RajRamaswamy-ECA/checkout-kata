using Checkout_Kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout_Kata
{
    public class Checkout : ICheckout
    {
        private List<Item> _itemsPrice { get; set; }
        public int TotalCheckoutItems
        {
            get
            {
                return ScannedItems.Values.Sum(d => d.Quantity);
            }
        }

        public Dictionary<string,ScannedItem> ScannedItems  = new Dictionary<string,ScannedItem>();

        public Checkout()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(Directory.GetParent(directoryPath).FullName).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "Input_Data.csv");
            _itemsPrice = ReadFromCSV.ReadCSV(filePath);
        }

        
        public void Scan(string item)
        {            
            var itemDetail = _itemsPrice.FirstOrDefault(d => d.ItemName == item.ToUpper());
            if (itemDetail != null)
            {
                if (ScannedItems.ContainsKey(item))
                {
                    ScannedItems[item].Quantity += 1;
                }
                else
                    ScannedItems.Add(item,new ScannedItem { ItemName = itemDetail.ItemName, UnitPrice = itemDetail.UnitPrice, Quantity = 1, SpecialPrice = itemDetail.SpecialPrice });
            }
            else
            {
                throw new Exception("Item Not Found");
            }
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in ScannedItems)
            {
                if (item.Value.SpecialPrice != null && item.Value.SpecialPrice.Quantity < item.Value.Quantity)
                {
                    int setsOfSpecialQuantity = item.Value.Quantity / item.Value.SpecialPrice.Quantity;
                    int remainder = item.Value.Quantity % item.Value.SpecialPrice.Quantity; ;
                    decimal totalForSets = setsOfSpecialQuantity * item.Value.SpecialPrice.SpecialItemPrice;
                    decimal totalForRemainder = remainder * item.Value.UnitPrice;
                    var totalItemPrice = totalForSets + totalForRemainder;
                    totalPrice += totalItemPrice;
                }
                else
                {
                    totalPrice += item.Value.UnitPrice * item.Value.Quantity;
                }
            }
            return totalPrice;
        }
    }
}
