using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout_Kata.Models
{
    public class Item
    {
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public  SpecialPrice? SpecialPrice { get; set; }
    }
}
