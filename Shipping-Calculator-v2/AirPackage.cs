/*
 * C9519
 * Program 1a
 * 11 October 2016
 * CIS 200-01
 * Abstract class from which is derived NextDayAirPackage and TwoDayAirPackage. Handles details
 * about overweight and oversized packages and calculates overage fees
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public abstract class AirPackage : Package
    {
        const double OVERWEIGHT = 75,   // Holds threshold of overweight packages
                     OVERSIZE = 100;    // Holds threshold of oversized packages

        // Precondition:  originAddress and destAddress must be valid address objects
        //                0 < length
        //                0 < width
        //                0 < height
        //                0 < weight
        // Postcondition: The specified values for origin address, destination address, 
        //                and size parameters are passed to base class to be set to the
        //                specified values for an air package
        public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
            : base(originAddress, destAddress, length, width, height, weight)
        {  }

        //Precondition:  None
        //Postcondition: returns whether package is overweight or not
        public bool IsHeavy()
        {
            if (Weight >= OVERWEIGHT)
                return true;
            else
                return false;
        }

        //Precondition:  None
        //Postcondition: returns whether package is oversized or not
        public bool IsLarge()
        {
            if (TotalSize >= OVERSIZE)
                return true;
            else
                return false;
        }

        // Precondition:  None
        // Postcondition: Returns base class' formatted string
        public override string ToString()
        {
            return base.ToString();
        }
    }
}