using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class Change
    {
        private int dimes;

        public int Dimes
        {
            get { return this.dimes; }
        }

        private int nickels;

        public int Nickels
        {
            get { return this.nickels; }
        }

        private int quarters;

        public int Quarters
        {
            get { return this.quarters; }
        }

        private double totalChange;

        public double TotalChange
        {
            get { return this.quarters * 25 + this.dimes * 10 + this.nickels * 5; }
        }

        public Change(decimal amountInDollars)
        {
            //do logic here to get the change.
            //dollars are passed in.
            amountInDollars = amountInDollars * 100;

            while (amountInDollars >= 25)
            {
                this.quarters += 1;
                amountInDollars -= 25;
            }

            while (amountInDollars >= 10)
            {
                this.dimes += 1;
                amountInDollars -= 10;
            }

            while (amountInDollars >= 5)
            {
                this.nickels += 1;
                amountInDollars -= 5;
            }
            
        }

        public Change(int amountInCents)
        {
            while (amountInCents >= 25)
            {
                this.quarters += 1;
                amountInCents -= 25;
            }

            while (amountInCents >= 10)
            {
                this.dimes += 1;
                amountInCents -= 10;
            }

            while (amountInCents >= 5)
            {
                this.nickels += 1;
                amountInCents -= 5;
            }

        }

        public bool Equals(object obj)
        {
            return true;
        }

    }
}
