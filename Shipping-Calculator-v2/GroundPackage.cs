/*
 * C9519
 * Program 1a
 * 11 October 2016
 * CIS 200-01
 * Creates a GroundPackage object and calculates the cost of shipping it
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public class GroundPackage : Package
    {
        private int _originZip,         // temporarily stores origniation zip code
                    _destinationZip;    // temporarily stores destination zip code
        const int MIN_ZIP = 0;          // Minimum ZipCode value
        const int MAX_ZIP = 99999;      // Maximum ZipCode value

        // Precondition:  originAddress and destAddress must be valid address objects
        //                0 < length
        //                0 < width
        //                0 < height
        //                0 < weight 
        // Postcondition: The Ground Package is created and the values for origin address,
        //                destination address, and size parameters are passed to the base 
        //                class to be set to the specified values
        public GroundPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
            : base(originAddress, destAddress, length, width, height, weight)
        {
            OriginZip = originAddress.Zip;      // sets the OriginZip property
            DestinationZip = destAddress.Zip;   // sets the DestinationZip property
        }

        private int OriginZip
        {
            // Precondition: None
            // Postcondition: The origination zip code is returned
            get { return _originZip; }
            // Precondition: 0 <= value <= 99999
            // Postcondition: origination zip code set to the specified value
            set
            {
                if (value >= MIN_ZIP && value <= MAX_ZIP)
                    _originZip = value;
                else
                    throw new ArgumentOutOfRangeException("ZIP", value,
                        "Origin zip code must be U.S. 5-digit zip code");
            }
        }

        private int DestinationZip
        {
            // Precondition: None
            // Postcondition: The destination zip code is returned
            get { return _destinationZip; }

            // Precondition:  MIN_ZIP <= value <= MAX_ZIP
            // Postcondition: The address' zip code has been set to the
            //                specified value
            set
            {
                if (value >= MIN_ZIP && value <= MAX_ZIP)
                    _destinationZip = value;
                else
                    throw new ArgumentOutOfRangeException("ZIP", value,
                        "Destination zip code must be U.S. 5-digit zip code");
            }
        }

        public int ZoneDistance
        {
            // Precondition:  MIN_ZIP <= OriginZip <= MAX_ZIP
            //                MIN_ZIP <= DestinationZip <= MAX_ZIP
            // Postcondition: The ground package's zone distance is returned.
            //                The zone distance is the positive difference between the
            //                first digit of the origin zip code and the first digit of
            //                the destination zip code
            get
            {
                const int FIRST_DIGIT_FACTOR = 10000; // Denominator to extract 1st digit

                return Math.Abs((OriginZip / FIRST_DIGIT_FACTOR) - (DestinationZip / FIRST_DIGIT_FACTOR));
            }
        }

        // Precondition:  0 < TotalSize
        //                0 <= ZoneDistance
        // Postcondition: The ground package's cost has been returned
        public override decimal CalcCost()
        {
            const decimal DIM_FACTOR = 0.20m,       // Dimension coefficient in cost equation
                          WEIGHT_FACTOR = 0.05m;    // Weight coefficient in cost equation
            const int ZONE_INCREMENT = 1;           // Adds 1 to zone in cost equation

            return (DIM_FACTOR * (decimal)(TotalSize) + WEIGHT_FACTOR * (ZoneDistance + ZONE_INCREMENT) * (decimal)Weight);
        }

        // Precondition:  None
        // Postcondition: Returns a formatted string of details about the ground package
        public override string ToString()
        {
            return string.Format("Ground Package{4}{0}{4}{1}{2}{4}Total Cost: {3:C}{4}",
                "--------------", base.ToString(), "------------------------------", CalcCost(), Environment.NewLine);
        }
    }
}