﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public class Letter : Parcel
    {
        private decimal fixedCost; // Cost to send letter

        // Precondition:  originAddress and destAddress must be valid address objects
        //                cost >= 0
        // Postcondition: The letter is created with the specified values for
        //                origin address, destination address, and cost
        public Letter(Address originAddress, Address destAddress,
            decimal cost)
            : base(originAddress, destAddress)
        {
            FixedCost = cost;
        }

        private decimal FixedCost // Helper property
        {
            // Precondition:  None
            // Postcondition: The letter's fixed cost has been returned
            get
            {
                return fixedCost;
            }

            // Precondition:  value >= 0
            // Postcondition: The letter's fixed cost has been set to the
            //                specified value
            set
            {
                if (value >= 0)
                    fixedCost = value;
                else
                    throw new ArgumentOutOfRangeException("FixedCost", value,
                        "FixedCost must be >= 0");
            }
        }

        // Precondition:  None
        // Postcondition: The letter's cost has been returned
        public override decimal CalcCost()
        {
            return FixedCost;
        }

        // Precondition:  None
        // Postcondition: A String with the letter's data has been returned
        public override string ToString()
        {
            return string.Format("Letter{4}{0}{4}{1}{2}{4}Total cost: {3:C}{4}",
                "------", base.ToString(), "------------------------------", CalcCost(), Environment.NewLine);

        }
    }
}