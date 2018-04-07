/*
 * C9519
 * Program0
 * 11 October 2016
 * CIS 200-01
 * Tests the other classes to ensure they are inputting and outputting correctly
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1a
{
    class Program
    {
        // Precondition:  None
        // Postcondition: List of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            Letter l1 = new Letter(a1, a3, 1.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.25M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.75M); // Test Letter 3

            GroundPackage gp1 = new GroundPackage(a1, a2, 12, 4, 2, 2); // Test ground package 1

            NextDayAirPackage ndap1 = new NextDayAirPackage(a2, a3, 12, 4, 2, 2, 25.00m); // Test next-day air package 1
            NextDayAirPackage ndap2 = new NextDayAirPackage(a4, a3, 75, 25, 10, 10, 30.00m); // Test next-day air package 2
            NextDayAirPackage ndap3 = new NextDayAirPackage(a1, a3, 12, 4, 2, 80, 15.00m); // Test next-day air package 3
            NextDayAirPackage ndap4 = new NextDayAirPackage(a1, a3, 75, 25, 20, 80, 20.00m); // Test next-day air package 4

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a3, a1, 12, 4, 2, 2, TwoDayAirPackage.Delivery.Saver); // Test two-day air package 1
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a4, a2, 12, 4, 2, 2, TwoDayAirPackage.Delivery.Early); // Test two-day air package 2


            List<Parcel> parcels = new List<Parcel>(); // Test list of parcels

            //Add test data to list
            parcels.Add(l1);
            parcels.Add(l2);
            parcels.Add(l3);
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(ndap4);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            // Display data
            Console.WriteLine($"Program 1a - List of Parcels\n");

            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                //System.Threading.Thread.Sleep(1000);
            }
        }
    }
}