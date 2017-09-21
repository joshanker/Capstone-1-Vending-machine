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
            get {return this.currentBalance; }
        }

        private Dictionary<string, List<VendingMachineItem>>  inventory;


        // private InventoryFileDAL inventorySource= 
        //private TransactionFileLog transactionLogger;

        private string[] slots;
        public string[] Slots
        {
            get { return this.slots; }
        }

        public void FeedMoney(int dollars)
        {
            this.currentBalance = this.currentBalance + dollars;
        }

        //public VendingMachineItem GetItemAtSlot(string slotId)
        //{
        //    //if bag of chips is avail
        //    //remove th bag of chips
        //    //return the bag of chips
        //    if (inventory.ContainsKey(slotId))
        //    {
        //        //return ;
        //    }
        //}

        public int GetQuantityRemaining(string slotId)
        {
            int qtyRemaining = 0;

            if(inventory.ContainsKey(slotId))
            {
               if(     inventory[slotId].Count() > 0);
                {
                    qtyRemaining = inventory[slotId].Count();
                }
            }


            return qtyRemaining;
                
        }

        public VendingMachineItem Purchase(string slotID)
        {

            bool StockExists = GetQuantityRemaining(slotID) > 0;
            bool isValidSlot = inventory.ContainsKey(slotID);
            bool isRichEnough = this.CurrentBalance >= inventory[slotID].First().PriceInCents;


            if ( StockExists && isValidSlot && isRichEnough)
            {
                this.currentBalance -= inventory[slotID].First().PriceInCents;
                inventory[slotID].RemoveAt(0);

            }
            return null;
            
        }


        //public Change ReturnChange()
        //{
        //  //  CurrentBalance = 0;
        // //   return 0; 
        //}


        public VendingMachine()
        {

            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
            InventoryFileDAL newMachine = new InventoryFileDAL(filePath);

            this.inventory = newMachine.GetInventory();

        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem> > inventory)
        {
            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
            InventoryFileDAL newMachine = new InventoryFileDAL(filePath);

            this.inventory = inventory;
        }



    }
}
