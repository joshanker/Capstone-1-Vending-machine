using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
     class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            VendingMachineCLI vmcli = new VendingMachineCLI(vm);
            vmcli.Run();
            Environment.Exit(0);
        }
    }
}
