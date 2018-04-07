/*
 * C9519
 * Program 1a
 * 11 October 2016
 * CIS 200-01
 * Creates a TwoDayAirPackage object and calculates the cost of shipping it
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public class TwoDayAirPackage : AirPackage
    {
        public enum Delivery { Early, Saver };  // creates enumerated list of delivery types
        private Delivery _delivery;             // temporarily holds delivery type

        // Precondition:  originAddress and destAddress must be valid address objects
        //                0 < length
        //                0 < width
        //                0 < height
        //                0 < weight 
        // Postcondition: The orignation and destination addresses are created and
        //                passed to the base class with the size parameters to be set to the specified
        //                values. The delivery type is set to the specified value
        public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, Delivery delivery)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            DeliveryType = delivery;
        }

        public Delivery DeliveryType
        {
            // Precondition: None
            // Postcondition: The delivery type is returned
            get { return _delivery; }
            // Precondition:  value > 0
            // Postcondition: delivery type set to the specified value
            set
            {
                if (value >= Delivery.Early && value <= Delivery.Saver)
                    _delivery = value;
                else
                    throw new ArgumentOutOfRangeException("DELIVERY", value,
                        "Delivery type must be Early or Saver.");
            }
        }

        // Precondition:  0 < TotalSize
        // Postcondition: Calculates the cost of shipping a package
        public override decimal CalcCost()
        {
            const double DIM_FACTOR = 0.25,     // Holds dimension coefficient in cost equation
                         WEIGHT_FACTOR = 0.25;  // Holds weight coefficient in cost equation
            const decimal DISCOUNT_RATE = 0.9m; // Savings if delivery not required to be early

            if (DeliveryType == Delivery.Saver)
                return ((decimal)(DIM_FACTOR * TotalSize) + (decimal)(WEIGHT_FACTOR * Weight)) * DISCOUNT_RATE;
            else
                return (decimal)(DIM_FACTOR * TotalSize) + (decimal)(WEIGHT_FACTOR * Weight);
        }

        // Precondition:  None
        // Postcondition: Returns a formatted string of details about the two-day air package
        public override string ToString()
        {
            return string.Format("Two-day Air{5}{0}{5}{1}Delivery Type: {2}{5}{3}{5}Total Cost: {4:C}{5}",
                "-----------", base.ToString(), DeliveryType, "------------------------------", CalcCost(), Environment.NewLine);
        }
    }
}