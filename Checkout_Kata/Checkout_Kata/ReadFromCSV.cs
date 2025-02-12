using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout_Kata.Models;

namespace Checkout_Kata
{
    public static class ReadFromCSV
    {
        public static List<Item> ReadCSV(string path)
        {
            List<Item> itemsPrice = new List<Item>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    Item price = new Item();
                    var line = reader.ReadLine();
                    if (line != null && line.StartsWith("SKU"))
                        continue;
                    var columns = line?.Split(',');
                    if (columns != null && columns.Length > 0)
                    {
                        price.ItemName = columns[0].ToString();
                        price.UnitPrice = int.Parse(columns[1]);
                        if (columns[2] != null)
                        {
                            var specialPrice = new SpecialPrice();
                            var specialPriceDetails = columns[2].Split(" for ");
                            if (!string.IsNullOrEmpty(specialPriceDetails[0]))
                            {
                                specialPrice.Quantity = int.Parse(specialPriceDetails[0]);
                                specialPrice.SpecialItemPrice = decimal.Parse(specialPriceDetails[1]);
                                price.SpecialPrice = specialPrice;
                            }
                        }
                        itemsPrice.Add(price);
                    }
                }
            }
            return itemsPrice;
        }
    }
}
