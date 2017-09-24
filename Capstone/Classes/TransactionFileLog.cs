using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class TransactionFileLog
    {
        private string filePath;
        string currentDirectory = Directory.GetCurrentDirectory();



        public void RecordDeposit(decimal depositAmount, decimal finalBalance)
        {
           
            WriteTransaction(System.DateTime.Now + " Money Fed".PadRight(13) + " | " + "Balances: ".PadRight(22) + " | " + depositAmount.ToString("C") + " | " + finalBalance.ToString("C"));
        }

        public void RecordPurchase(string productName, string slotID, decimal initialBalance, decimal finalBalance)
        {
           
            WriteTransaction(System.DateTime.Now + " Purchase".PadRight(13) + " | " + slotID + " " + productName.PadRight(19) + " | " + initialBalance.ToString("C").PadRight(6) + " | " + finalBalance.ToString("C") );
        }

        public void RecordCompleteTransaction(decimal initialAmount)
        {
           
            WriteTransaction(System.DateTime.Now + " Change given".PadRight(13) +  " | " + "Balances: ".PadRight(22) + " | " + initialAmount.ToString("C").PadRight(6) + " | " + "$0.00");

        }

      

      



        public TransactionFileLog(string filePath)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachinelog.txt");

        }

        public void WriteTransaction(string message)
        {
            try
            {
                filePath = Path.Combine(currentDirectory, "vendingmachinelog.txt");

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(message);
                }
                    
                

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }


    }
}
