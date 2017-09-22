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

        private Dictionary<string, List<VendingMachineItem>> inventory;



        // private InventoryFileDAL inventorySource= 
        //private TransactionFileLog transactionLogger;

        //private string[] slots;
        public string[] Slots
        {
            get { return this.inventory.Keys.ToArray(); }
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

            bool isValidSlot = inventory.ContainsKey(slotID);
            if (isValidSlot)
            {
                bool StockExists = GetQuantityRemaining(slotID) > 0;
                bool isRichEnough = this.CurrentBalance >= inventory[slotID].First().PriceInCents;

                if (StockExists && isValidSlot && isRichEnough)
                {
                    this.currentBalance -= inventory[slotID].First().PriceInCents;
                    inventory[slotID].RemoveAt(0);
                    return inventory[slotID].First();
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



    }
}
