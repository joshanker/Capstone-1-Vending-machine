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

        public void RecordCompleteTransaction(decimal initialAmount)
        {
            //WriteTransaction($"{System.DateTime.Now} Change given {initialAmount}  | Current balance  $0.00");
            WriteTransaction(System.DateTime.Now + "Change given".PadRight(15) +  initialAmount.ToString("C").PadRight(8) + "|" + "Current balance" + "$0.00");

        }

        public void RecordDeposit(decimal depositAmount, decimal finalBalance)
        {
            //WriteTransaction($"{System.DateTime.Now} Money Fed: {depositAmount}. Current balance: {finalBalance}");
            WriteTransaction(System.DateTime.Now +  "Money Fed:".PadRight(15) + depositAmount. + "Current balance:".PadRight(8) + finalBalance);
        }

        public void RecordPurchase(string productName, string slotID, decimal initialBalance, decimal finalBalance)
        {
            WriteTransaction($"{System.DateTime.Now} Purchase {slotID} {productName}: Initial Amount|Final Amount {initialBalance}|{finalBalance} ");

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
