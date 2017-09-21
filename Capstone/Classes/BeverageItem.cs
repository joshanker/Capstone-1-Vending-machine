using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class BeverageItem : VendingMachineItem
    {
        public BeverageItem(string itemName, decimal price) : base(itemName, price)
        {
        }

        public override string Consume()
        {
            return "Glug Glug, Yuum!";
        }
    }
}
