/*
 * C9519
 * Program 1a
 * 11 October 2016
 * CIS 200-01
 * Creates a NextDayAirPackage object and calculates the cost of shipping it
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public class NextDayAirPackage : AirPackage
    {

        private decimal _expressFee;            //temporarily stores express fee
        const double OVERSIZE_CHARGE = 0.25,    // Holds oversize charge 
                     OVERWEIGHT_CHARGE = 0.25,  // Holds overweight charge
                     DIM_FACTOR = 0.4,          // Holds dimension coefficient in cost equation
                     WEIGHT_FACTOR = 0.25;      // Holds weight coefficient in cost equation

        // Precondition:  originAddress and destAddress must be valid address objects
        //                0 < length
        //                0 < width
        //                0 < height
        //                0 < weight 
        //                0 <= ExpressFee
        // Postcondition: The Next Day Air Package is created and the values for origin address,
        //                destination address, and size parameters are passed to the base class
        //                to be set to the specified values, and the express fee is set to the
        //                specified value
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressFee)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        public decimal ExpressFee
        {
            //Precondition:  None
            //Postcondition: The express fee is returned
            get { return _expressFee; }
            //Precondition:  Express fee >= 0
            //Postcondition: Express fee set to the specified value
            private set
            {
                if (value >= 0)
                    _expressFee = value;
                else
                    throw new ArgumentOutOfRangeException("EXPRESS FEE", value,
                        "Express fee must be greater than or equal to zero.");
            }
        }

        //Precondition:  Express fee >= 0
        //Postcondition: Calculates the total cost of shipping a package
        public override decimal CalcCost()
        {
            decimal baseCost = (decimal)(DIM_FACTOR * TotalSize) + (decimal)(WEIGHT_FACTOR * Weight) + ExpressFee;  // Holds base cost of shipping a next day air package
            decimal overweightFee = (decimal)(Weight * OVERWEIGHT_CHARGE);  // Holds calculoated overweight fee
            decimal oversizeFee = (decimal)(TotalSize * OVERSIZE_CHARGE);   // Holds calculated oversize fee

            if (IsHeavy() && IsLarge())
                return baseCost + overweightFee + oversizeFee;
            else if (IsHeavy())
                return baseCost + overweightFee;
            if (IsLarge())
                return baseCost + oversizeFee;
            else
                return baseCost;
        }

        //Precondition:  None
        //Postcondition: Returns a formatted string of details about the next-day air package
        public override string ToString()
        {
            decimal overageFee;    // Holds overage fee
            string feeString = $"Next Day Air\r\n------------\r\n{base.ToString()}Base Charge: {((decimal)(DIM_FACTOR * TotalSize) + (decimal)(WEIGHT_FACTOR * Weight)).ToString("C")}\r\nExpress Fee: {ExpressFee}\r\n";

            if (IsHeavy())
            {
                overageFee = (decimal)(Weight * OVERWEIGHT_CHARGE);
                feeString += $"Overweight Charge: {overageFee:C}\r\n";
            }

            if (IsLarge())
            {
                overageFee = (decimal)(TotalSize * OVERSIZE_CHARGE);
                feeString += $"Oversize Charge: {overageFee:C}\r\n";
            }
            return $"{feeString}------------------------------\r\nTotal Cost: {CalcCost():C}\r\n";
        }
    }
}