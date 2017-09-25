using System;
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
        private string filePath;
        private const int InitialQuantity = 5;
        private const int Product = 1;
        private const int SlotID = 0;

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>();

           
            //string currentDirectory = Directory.GetCurrentDirectory();
            try
            {
                //filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
                using (StreamReader sr = new StreamReader(filePath))
                {

                    while (!sr.EndOfStream)
                    {
                        string nextline = sr.ReadLine();
                        
                        string[] tempArray = nextline.Split('|');

                        List<VendingMachineItem> vmiList = ParseInventoryLine(tempArray);

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

        private List<VendingMachineItem> ParseInventoryLine(string[] tempArray)
        {
            List<VendingMachineItem> vmiList = new List<VendingMachineItem>();

            if (tempArray[SlotID].StartsWith("A"))
            {
                for (int i = 0; i < 5; i++)
                {
                    ChipItem chips = new ChipItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                    vmiList.Add(chips);
                }
            }

            if (tempArray[SlotID].StartsWith("B"))
            {
                for (int i = 0; i < 5; i++)
                {
                    CandyItem candy = new CandyItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                    vmiList.Add(candy);
                }
            }

            if (tempArray[SlotID].StartsWith("C"))
            {
                for (int i = 0; i < 5; i++)
                {
                    BeverageItem bev = new BeverageItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                    vmiList.Add(bev);
                }
            }


            if (tempArray[SlotID].StartsWith("D"))
            {
                for (int i = 0; i < 5; i++)
                {
                    GumItem gum = new GumItem(tempArray[Product], decimal.Parse(tempArray[Cost]));
                    vmiList.Add(gum);
                }
            }

            return vmiList;
        }


        public InventoryFileDAL(string filepath)
        {
            this.filePath = filepath;
        }


    }

}

