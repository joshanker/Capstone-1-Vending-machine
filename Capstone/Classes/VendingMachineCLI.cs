using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
//using System.Collections;


namespace Capstone.Classes
{
    public class VendingMachineCLI
    {

        private string Option_DisplatPurchaseMenu;
        private string Option_DisplayVEndingMachine;
        private string Option_InsertMoney;
        private string Option_MakeSelection;
        private string Option_Quit;
        private string Option_ReturnChange;
        private string Option_ReturnToPreviousMenu;
        private VendingMachine vm;


        private void DisplayInvalidOption()
        {
            Console.WriteLine("Sorry, you have entered an invalid option.");
        }


        private void DisplayInventory()
        {
            string[] slots = vm.Slots;
            Console.WriteLine();
            Console.WriteLine("===========================================");
            for (int i = 0; i < slots.Length; i++)
            {


                decimal priceOfItem = vm.GetItemAtSlot(slots[i]).PriceInCents;
                string nameOfItem = vm.GetItemAtSlot(slots[i]).ItemName;
                int quantity = vm.GetQuantityRemaining(slots[i].ToString());

                Console.WriteLine($"{slots[i].PadRight(2)} | {quantity.ToString().PadRight(2)}| {nameOfItem.PadRight(20)} |  {priceOfItem.ToString("C")}");
                // Console.WriteLine($"{slots[i]}  {vm.GetItemAtSlot(slots[i]).ItemName} {vm.GetItemAtSlot(slots[i]).PriceInCents.ToString("C")}");
            }

            Console.WriteLine("===========================================");
            Console.WriteLine();
        }

        private void DisplayPurchaseMenu()
        {

        }

        private void DisplayReturnedChange()
        {

            Console.WriteLine("Calculating remaining change: ");
            Console.WriteLine("Quarters: ");
            Console.WriteLine("Dimes: ");
            Console.WriteLine("Nickels: ");

        }

        private void PrintTitle()
        {

        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(" (1) Display Vending Machine Items" +
                    "\n (2) Purchase");
                Console.WriteLine();
                string input = Console.ReadLine();
                
                if (input == "1")
                {
                    DisplayInventory();
                }
                if (input == "2")
                {
                    DisplayPurchaseMenu();
                }

            }
        }

        public VendingMachineCLI(VendingMachine vm)
        {
            this.vm = vm;
        }







    }
}
