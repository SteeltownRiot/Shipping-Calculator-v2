using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    public abstract class Parcel
    {
        // Precondition:  originAddress and destAddress must be valid address objects
        // Postcondition: The specified values for origin address and destination
        //                address are assigned for a parcel
        public Parcel(Address originAddress, Address destAddress)
        {
            OriginAddress = originAddress;
            DestinationAddress = destAddress;
        }

        public Address OriginAddress
        {
            // Precondition:  None
            // Postcondition: The parcel's origin address has been returned
            get;
            // Precondition:  None
            // Postcondition: The parcel's origin address has been set to the
            //                specified value
            set;
        }

        public Address DestinationAddress
        {
            // Precondition:  None
            // Postcondition: The parcel's destination address has been returned
            get;
            // Precondition:  None
            // Postcondition: The parcel's destination address has been set to the
            //                specified value
            set;
        }

        // Precondition:  None
        // Postcondition: The parcel's cost has been returned
        public abstract decimal CalcCost();

        // Precondition:  None
        // Postcondition: A String with the parcel's data has been returned
        public override String ToString()
        {
            return string.Format("Origin Address:{2}{0}{2}{2}Destination Address:{2}{1}{2}",
                OriginAddress, DestinationAddress, Environment.NewLine);
        }
    }
}