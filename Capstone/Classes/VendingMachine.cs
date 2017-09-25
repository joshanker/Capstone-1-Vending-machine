using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine 
    {
        private decimal currentBalance;

        public decimal CurrentBalance
        {
            get { return this.currentBalance; }
        }

        protected Dictionary<string, List<VendingMachineItem>> inventory;

        public string[] Slots
        {
            get { return this.inventory.Keys.ToArray(); }
        }

        public bool DoesVendingMachineContainSlot(string slot)
        {
            return this.inventory.ContainsKey(slot);
        }

        public void FeedMoney(int dollars)
        {
            this.currentBalance = this.currentBalance + dollars;
        }

        public VendingMachineItem GetItemAtSlot(string slotId)
        {
            List<VendingMachineItem> itemsInSlot = inventory[slotId];
            return itemsInSlot[0];
        }

        public int GetQuantityRemaining(string slotId)
        {
            int qtyRemaining = 0;

            if (inventory.ContainsKey(slotId))
            {
                if (inventory[slotId].Count() > 0)
                {
                    qtyRemaining = inventory[slotId].Count();
                }
            }
            return qtyRemaining;

        }

        public VendingMachineItem Purchase(string slotID)
        {
            // Check here to see if the slot is invalid - then throw the exception
            // Check here to see if there is enough inventory - then throw the exception
            // Check here to see if there is enough money - then throw the exception

            bool isValidSlot = inventory.ContainsKey(slotID);
            if (isValidSlot)
            {
                bool StockExists = GetQuantityRemaining(slotID) > 0;
                bool isRichEnough = this.CurrentBalance >= inventory[slotID].First().PriceInCents;

                if (StockExists && isValidSlot && isRichEnough)
                {
                    this.currentBalance -= inventory[slotID].First().PriceInCents;
                    inventory[slotID].RemoveAt(0);

                }
               

            }
            return null;
        }


        public Change ReturnChange()
        {
           Change customersChange = new Change(this.currentBalance);
            this.currentBalance = 0;
            return customersChange;
        }


        public VendingMachine()
        {

            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
            InventoryFileDAL newMachine = new InventoryFileDAL(filePath);

            this.inventory = newMachine.GetInventory();

        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem>> inventory)
        {
            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
            InventoryFileDAL newMachine = new InventoryFileDAL(filePath);

            this.inventory = inventory;
        }

        public decimal GetCostOfItem(string slotID)
        {
            return inventory[slotID][0].PriceInCents;
        }

    }
}
