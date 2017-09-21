using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        private string itemName;
        private decimal priceInCents;
        
        public virtual string ItemName
        {
            get { return this.itemName; }
        }

        public decimal PriceInCents
        {
            get { return this.priceInCents; }
        }

        public abstract string Consume();

        public VendingMachineItem(string itemName, decimal price)
        {
            this.itemName = itemName;
            this.priceInCents = price;
        }

    }
}
