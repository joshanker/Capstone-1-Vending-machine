using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class VendingMachineException : Exception
    {
        public VendingMachineException(string message)

            : base(message)
        {

        }

    }
}
