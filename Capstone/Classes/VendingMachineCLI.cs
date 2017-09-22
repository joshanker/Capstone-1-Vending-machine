using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;



namespace Capstone.Classes
{
    public class VendingMachineCLI
    {

        private string Option_DisplatPurchaseMenu;
        private string Option_DisplayVendingMachine;
        private string Option_InsertMoney;
        private string Option_MakeSelection;
        private string Option_Quit;
        private string Option_ReturnChange;
        private string Option_ReturnToPreviousMenu;
        private VendingMachine vm;

        TransactionFileLog logger = new TransactionFileLog(" ");


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

            while (true)
            {
            Console.WriteLine();
            Console.WriteLine(" (1) Feed Me, Seymour" +
                    "\n (2) Select Product" + "\n (3) Finish Transaction");
            string input = Console.ReadLine();

            if(input == "1")
            {
                    Console.WriteLine("Please feed Seymour some money (enter dollars 1 | 2 | 5 | 10)");
                    string moneyEntered = Console.ReadLine();
                    if(moneyEntered == "1" || moneyEntered == "2" || moneyEntered == "5" || moneyEntered == "10")
                    {
                        vm.FeedMoney(int.Parse(moneyEntered));
                        Console.WriteLine("Money added! Treat yo self!");
                        Console.WriteLine($"You have ${vm.CurrentBalance} to spend!");
                        logger.RecordDeposit(int.Parse(moneyEntered), vm.CurrentBalance);
                    }
                    else
                    {
                        Console.WriteLine("Hmm, something doesn't look right.");

                    }

                }
                if (input == "2")
            {
                   
                    DisplayInventory();
                    Console.WriteLine("Please select your item using the slot ID");
                    string itemToVend = Console.ReadLine().ToUpper();
                    bool weCanAffordIt = vm.GetCostOfItem(itemToVend) <= vm.CurrentBalance;
                    if (vm.Slots.Contains(itemToVend) && weCanAffordIt)
                    {
                        vm.Purchase(itemToVend); //if item is sold out or don't have enought money?
                        decimal oldBalance = vm.CurrentBalance;
                        Console.WriteLine($"Thanks for buying {vm.GetItemAtSlot(itemToVend).ItemName} - you have ${vm.CurrentBalance} left.");
                        Console.WriteLine(vm.GetItemAtSlot(itemToVend).Consume());
                        logger.RecordPurchase(vm.GetItemAtSlot(itemToVend).ItemName, itemToVend, oldBalance, vm.CurrentBalance);
                    }
                    else
                    {
                        Console.WriteLine("Item does not exist. Are you sure you entered a slot ID? Try again!");
                    }

                }
            if(input == "3")
            {
                    DisplayReturnedChange();
                    vm.ReturnChange();
                    Console.WriteLine("Balance should be $0, your change should be printed.");
                    logger.RecordCompleteTransaction(vm.CurrentBalance);
            }
            }
        }

        private void DisplayReturnedChange()
        {
            Change bling = new Change(vm.CurrentBalance);
            //vm.ReturnChange();
            Console.WriteLine("Here's your change:");
            Console.WriteLine($"{ bling.Quarters} quarters");
            Console.WriteLine($"{ bling.Dimes} dimes");
            Console.WriteLine($"{ bling.Nickels} nickels");
            Console.WriteLine();
        }

        private void PrintTitle()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine("** WELCOME TO OUR CRAPPY VENDING MACHINE **");
            Console.WriteLine("*******************************************");
            Console.WriteLine("*******************************************");
            Console.WriteLine();
        }

        public void Run()
        {
            while (true)
            {
                PrintTitle();
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
