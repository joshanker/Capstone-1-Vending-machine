﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class InventoryFileDAL
    {
        private const int Cost = 2;
        private string FilePath;
        private int InitialQuantity;
        private const int Product = 1;
        private const int SlotID = 0;

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();

            //FilePath = @"C:\Users\Joshua Anker\Desktop\c - module - 1 - capstone - team - 0\Capstone\vendingmachineInventory.txt";
            string currentDirectory = Directory.GetCurrentDirectory();
            try
            {
                FilePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
                using (StreamReader sr = new StreamReader(FilePath))
                {

                    while (!sr.EndOfStream)
                    {
                        string nextline = sr.ReadLine();
                        List<VendingMachineItem> vmiList = new List<VendingMachineItem>();

                        string[] tempArray = nextline.Split('|');

                        if(tempArray[SlotID].StartsWith("A"))
                        {

                            for (int i = 0; i < 5; i++)
                            {
                                ChipItem chips = new ChipItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                                vmiList.Add(chips);//do 5 times
                            }

                        }

                        if (tempArray[SlotID].StartsWith("B"))
                        {

                            for (int i = 0; i < 5; i++)
                            {
                                CandyItem candy = new CandyItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                                vmiList.Add(candy);//do 5 times
                            }

                        }

                        if (tempArray[SlotID].StartsWith("C"))
                        {

                            for (int i = 0; i < 5; i++)
                            {
                                BeverageItem bev = new BeverageItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                                vmiList.Add(bev);//do 5 times
                            }

                        }


                        if (tempArray[SlotID].StartsWith("D"))
                        {

                            for (int i = 0; i < 5; i++)
                            {
                                GumItem gum = new GumItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                                vmiList.Add(gum);//do 5 times
                            }

                        }

                        inventory[tempArray[SlotID]] = vmiList;
                    }
                    

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("we got errs.");
                Console.WriteLine(ex);
            }
            return inventory;
            
        }

        public InventoryFileDAL(string filepath)
        {
             
        }


    }

}
