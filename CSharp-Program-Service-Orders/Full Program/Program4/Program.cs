// Program 4
// CIS 199-01
// Due: 12/01/2020
// By: R1466

// This program uses a created class named ServiceOrder to create indivdual service orders and hold relevant data for each one.
// The main method constructs six ServiceOrder objects each with different data and declares an array to hold them.
// A user defined method is used to first calculate the appropriate cost for each order, then the properties of each order are displayed to the console.
// Data for each object in the array is changed, then the DisplayServiceOrder method is run again to calculate and display the data a second time.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                // An array that can hold six ServiceOrder objects is created.
                ServiceOrder[] serviceOrders = new ServiceOrder[6];

                // Six individual ServiceOrder objects are constructed using the user created constructor, and assigned a position in the new array.
                serviceOrders[0] = new ServiceOrder(11111, "AA111", "XX11111111", 15, "Alice Anderson", true);      
                serviceOrders[1] = new ServiceOrder(22222, "AA222", "XX22222222", 30, "Bob Baker", true);
                serviceOrders[2] = new ServiceOrder(33333, "AA333", "XX33333333", 45, "Cliff Custard", true);
                serviceOrders[3] = new ServiceOrder(44444, "AA444", "XX44444444", 60, "Dave Davidson", false);
                serviceOrders[4] = new ServiceOrder(55555, "AA555", "XX55555555", 120, "Emily Emerson", false);
                serviceOrders[5] = new ServiceOrder(66666, "AA666", "XX66666666", 180, "Frank Fontaine", false);

                // Calls user defined method to calculate costs and display properties of the passed array to the console.
                DisplayServiceOrder(serviceOrders);

                // Each object has one property altered. Most below do not pass validation in the property set assessor, and will default to default data.
                serviceOrders[0].ZipCode = -1;
                serviceOrders[1].ModelNum = "";
                serviceOrders[2].SerialNum = "";
                serviceOrders[3].AppMinutes = 0;
                serviceOrders[4].TechName = "";
                serviceOrders[5].HasWarranty = true;

                WriteLine("----After information update----");
                WriteLine();

                // Calls user defined method a second time to calculate costs and display updated properties of the passed array to the console.
                DisplayServiceOrder(serviceOrders);
            }
        }
        // User defined method for displaying object properties.
        // Uses a foreach loop to calculate and display for each index in the array.
        // Preconditions: Objects are instantiated within a passed array.
        public static void DisplayServiceOrder(ServiceOrder[] orders)   // Requires a passed array
        {
            foreach (ServiceOrder i in orders)
            {
                i.Cost = i.CalcCost();      // Calls method defined in class to return object's calculated costs to it's own property.
                WriteLine(i.ToString());    // Uses overridden ToString() to display object's properties to the console.
            }
        }
        //Postconditions: Relevant data for each object is calculated and displayed to the console.
    }
}
