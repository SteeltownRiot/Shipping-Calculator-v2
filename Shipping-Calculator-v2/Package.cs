/*
 * C9519
 * Program 1a
 * 11 October 2016
 * CIS 200-01
 * Abstract class from which is derived GroundPackage and AirPackage. Handles the size and weight parameters
 * along with the total dimensions for all derived packages
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public abstract class Package : Parcel
    {
        private double _totalSize,  // temporarily value of packages dimensions
                       _length,     // temporarily stores package length
                       _width,      // temporarily stores package width
                       _height,     // temporarily stores package height
                       _weight;     // temporarily stores package weight

        // Precondition:  originAddress and destAddress must be valid address objects
        //                0 < length
        //                0 < width
        //                0 < height
        //                0 < weight
        // Postcondition: The specified values for origin address, and destination address
        //                are passed to the base class to be set to be assigned the specifed
        //                values, and the size parameters are created with the specified values
        //                for a package
        public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight)
            : base(originAddress, destAddress)
        {
            Length = length;                        // set the Length property
            Width = width;                          // set the Width property
            Height = height;                        // set the Height property
            Weight = weight;                        // set the Weight property
            TotalSize = Length + Width + Weight;    // sets the total size property
        }

        public double Length
        {
            // Precondition:  None
            // Postcondition: The package length is returned
            get { return _length; }
            // Precondition: value > 0
            // Postcondition: package length set to the specified value
            set
            {
                if (value > 0)
                    _length = value;
                else  // When invalid, set to 0 instead
                    throw new ArgumentOutOfRangeException("LENGTH", value,
                        "Length must be greater than zero");
            }
        }

        public double Width
        {
            // Precondition:  None
            // Postcondition: The package width is returned
            get { return _width; }
            // Precondition: value > 0
            // Postcondition: package width set to the specified value
            set
            {
                if (value > 0)
                    _width = value;
                else  
                    throw new ArgumentOutOfRangeException("WIDTH", value,
                        "Width must be greater than zero");
            }
        }

        public double Height
        {
            // Precondition:  None
            // Postcondition: The package height is returned
            get { return _height; }
            // Precondition: value > 0
            // Postcondition: package height set to the specified value
            set
            {
                if (value > 0)
                    _height = value;
                else  
                    throw new ArgumentOutOfRangeException("HEIGHT", value,
                        "Height must be greater than zero");
            }
        }

        public double Weight
        {
            // Precondition:  None
            // Postcondition: The package weight is returned
            get { return _weight; }
            // Precondition: value > 0
            // Postcondition: package weight set to the specified value
            set
            {
                if (value > 0)
                    _weight = value;
                else  
                    throw new ArgumentOutOfRangeException("WEIGHT", value,
                        "Weight must be greater than zero");
            }
        }

        protected double TotalSize
        {
            // Precondition:  None
            // Postcondition: The package weight is returned
            get { return _totalSize; }
            // Precondition:  value > 0
            // Postcondition: package weight set to the specified value
            set
            {
                if (value > 0)
                    _totalSize = value;
                else  
                    throw new ArgumentOutOfRangeException("DIMENSIONS", value,
                        "Total dimensions must be greater than zero");
            }
        }

        // Precondition:  None
        // Postcondition: Returns a formatted string of details about the package
        public override string ToString()
        {
            return string.Format("{0}{5}Package Detalis:{5}Length: {1} in. Width: {2} in.{5}Height: {3} in. Weight: {4} in.{5}",
                base.ToString(), Length, Width, Height, Weight, Environment.NewLine);
        }
    }
}