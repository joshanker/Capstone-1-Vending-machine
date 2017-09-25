using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;
using Capstone.Exceptions;


namespace Capstone.Classes
{
    public class VendingMachineCLI : VendingMachine
    {

        private VendingMachine vm;

        TransactionFileLog logger = new TransactionFileLog(" ");


        private void DisplayInvalidOption()
        {
            Console.WriteLine("Sorry, you have entered an invalid option.");
        }


        private void DisplayInventory()
        {
            string[] slots = vm.Slots;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===========================================");
            for (int i = 0; i < slots.Length; i++)
            {

                if (vm.GetQuantityRemaining(slots[i]) > 0)
                {
                    decimal priceOfItem = vm.GetItemAtSlot(slots[i]).PriceInCents;
                    string nameOfItem = vm.GetItemAtSlot(slots[i]).ItemName;
                    int quantity = vm.GetQuantityRemaining(slots[i].ToString());

                    Console.WriteLine($"{slots[i].PadRight(2)} | {quantity.ToString().PadRight(2)}| {nameOfItem.PadRight(20)} |  {priceOfItem.ToString("C")}");
                }
                else
                {
                    decimal priceOfItem = 0.00M;
                    string nameOfItem = "Sold out.";
                    int quantity = 0;

                    Console.WriteLine($"{slots[i].PadRight(2)} | {quantity.ToString().PadRight(2)}| {nameOfItem.PadRight(20)} |  {priceOfItem.ToString("C")}");
                }

            }

            Console.WriteLine("===========================================");
            Console.WriteLine();
            Console.ResetColor();
        }

        private void DisplayPurchaseMenu()
        {

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.WriteLine(" (1) Feed Me, Seymour" +
                    "\n (2) Select Product" + "\n (3) Finish Transaction");
                Console.WriteLine("===========================================");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Please feed money into SnackBot (enter dollars 1 | 2 | 5 | 10)");
                    string moneyEntered = Console.ReadLine();
                    if (moneyEntered == "1" || moneyEntered == "2" || moneyEntered == "5" || moneyEntered == "10")
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
                    bool weCanAffordIt;
                    try
                    {

                        if (!inventory.ContainsKey(itemToVend))
                        {
                            throw new InvalidSlotIDException("That Slot ID doesn't exist.");

                        }


                    }
                    catch (InvalidSlotIDException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }



                    try
                    {

                        if (vm.GetQuantityRemaining(itemToVend) == 0)
                        {
                            throw new OutOfStockException("Sorry, that item is sold out!");
                        }
                    }
                    catch (OutOfStockException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }


                    try
                    {
                        weCanAffordIt = vm.GetCostOfItem(itemToVend) <= vm.CurrentBalance;
                        if (!weCanAffordIt)
                        {
                            throw new InsufficientFundsException("Sorry, you can't afford that item.  Your balance is: " + vm.CurrentBalance.ToString("C") + ".");
                        }
                    }
                    catch (InsufficientFundsException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }


             

                    decimal oldBalance = vm.CurrentBalance;
                    Console.WriteLine($"Thanks for buying {vm.GetItemAtSlot(itemToVend).ItemName} - you have ${vm.CurrentBalance- vm.GetCostOfItem(itemToVend)} left.");
                    Console.WriteLine(vm.GetItemAtSlot(itemToVend).Consume());
                    logger.RecordPurchase(vm.GetItemAtSlot(itemToVend).ItemName, itemToVend, oldBalance, vm.CurrentBalance-vm.GetCostOfItem(itemToVend));

                    vm.Purchase(itemToVend);
                    

                }
                if (input == "3")
                {
                    logger.RecordCompleteTransaction(vm.CurrentBalance);
                    DisplayReturnedChange();
                    vm.ReturnChange();
                    Console.WriteLine("Balance is now $0; your change should be printed.");
                    
                    Run();
                }
            }
        }


      




        private void DisplayReturnedChange()
        {
            Change bling = new Change(vm.CurrentBalance);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Here's your change:");
            Console.WriteLine($"{ bling.Quarters} quarters");
            Console.WriteLine($"{ bling.Dimes} dimes");
            Console.WriteLine($"{ bling.Nickels} nickels");
            Console.WriteLine();
            Console.ResetColor();
        }

        private void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var arr = new[]
            {
                 @"                    ::::::::    ::::    :::       :::        ::::::::    :::    :::    :::::::::     ::::::::    ::::::::::: 
                   :+:    :+:   :+:+:   :+:     :+: :+:     :+:    :+:   :+:   :+:     :+:    :+:   :+:    :+:       :+:     
                   +:+          :+:+:+  +:+    +:+   +:+    +:+          +:+  +:+      +:+ +:+      +:+    +:+       +:+
                   +#++:++#++   +#+ +:+ +#+   +#++:++#++:   +#+          +#++:++       +#++:++#+    +#+    +:+       +#+     
                          +#+   +#+  +#+#+#   +#+     +#+   +#+          +#+  +#+      +#+    +#+   +#+    +#+       +#+     
                   #+#    #+#   #+#   #+#+#   #+#     #+#   #+#    #+#   #+#   #+#     #+#    #+#   #+#    #+#       #+#     
                    ########    ###    ####   ###     ###    ########    ###    ###    #########     ########        ###     "
            };
            Console.WindowWidth = 160;
            Console.WriteLine("\n\n");
            foreach (string line in arr)
            Console.WriteLine(line);
            Console.ResetColor();

        }

        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                PrintTitle();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.WriteLine(" (1) Display Vending Machine Items" +
                    "\n (2) Purchase" + "\n (3) Exit");
                Console.WriteLine("===========================================");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (input == "1")
                {
                    DisplayInventory();
                }
                if (input == "2")
                {
                    DisplayPurchaseMenu();
                }
                if (input == "3")
                {
                    keepRunning = false;
                    Environment.Exit(0);
                }

            }
        }

        public VendingMachineCLI(VendingMachine vm)
        {
            this.vm = vm;
        }

    }
}
