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

namespace Program4
{
    class ServiceOrder
    {
        //defaults
        private const int ZIP_DEFAULT = 40204;                  // Default data used when validation in ZipCode property when fails to be a 5 digit int between 00000 and 99999.
        private const string MODEL_DEFAULT = "B1234";           // Default data used when validation in ModelNum property fails to be a 5 digit string.
        private const string SERIAL_DEFAULT = "C123456789";     // Default data used when validation in SerialNum property fails to be a 10 digit string.
        private const string TECH_DEFAULT = "John Smith";       // Default data used when validation in TechName property when is an empty string or only whitespace.
        private const int TIME_DEFAULT = 30;                    // Default data used when validation in AppMinutesNum property fails to be between 15 and 180 minutes.

        //constants
        private const double WARRANTY_BASE_COST = 20.0;         // Total cost when a service order falls under a warranty.
        private const double NO_WARRANTY_BASE_COST = 25.0;      // Base cost for non-warranty service orders.
        private const double FEE_PER_MIN = 1.5;                 // Amount charged per minute on non-warranty service orders.
        private const double MINS_TO_HOURS = 60.0;              // Used to convert appointment minutes into appointment hours. Divide minutes by this constant.
        private const int TIME_MIN = 15;                        // Used to validate AppMinutes data. Appointments are a minimum of 15 minutes long.
        private const int TIME_MAX = 180;                       // Used to validate AppMinutes data. Appointments are a maximum of 180 minutes long.
        private const int ZIP_MIN = 00000;                      // Used to validate ZipCode data. Zip Codes must be between 00000 and 99999 (inclusive).
        private const int ZIP_MAX = 99999;                      // Used to validate ZipCode data. Zip Codes must be between 00000 and 99999 (inclusive).

        //backing fields
        private int _zipCode;                                   // Backing field for Zip Code property. Private so it cannot be accessed from main program.
        private string _modelNum;                               // Backing field for Model Number property. Private so it cannot be accessed from main program.
        private string _serialNum;                              // Backing field for Serial Number property. Private so it cannot be accessed from main program.
        private string _techName;                               // Backing field for Technician Name property. Private so it cannot be accessed from main program.
        private int _appMinutes;                                // Backing field for Appointment Minutes property. Private so it cannot be accessed from main program.
        private bool _hasWarranty;                              // Backing field for Has Warranty bool property. Private so it cannot be accessed from main program.
        private double _cost;                                   // Backing field for Cost property. Private so it cannot be accessed from main program.

        // User defined constructor to accept the object's needed property data.
        // Preconditions: All arguments pass validation in the associated property.
        public ServiceOrder(int zipCode, string modelNumber, string serialNumber, int appMinutes, string techName, bool hasWarranty)
        {
            ZipCode = zipCode;              // converts passed argument into the appropraite Property.
            ModelNum = modelNumber;
            SerialNum = serialNumber;
            AppMinutes = appMinutes;
            TechName = techName;
            HasWarranty = hasWarranty;
        }
        // Postconditions: an object of ServiceOrder is created.

        // Object Properties

        // Property to hold service order's Zip Code. Validated in set assessor.
        // Preconditions: Zip Code must be between 00000 and 99999.
        public int ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                if (value >= ZIP_MIN && value <= ZIP_MAX)       // Zip Code must be between 00000 and 99999. If not, default data is used.
                    _zipCode = value;
                else
                    _zipCode = ZIP_DEFAULT;
            }
        }
        // Postconditions: Zip Code is returned.

        // Property to hold service order's Model Number. Validated in set assessor.
        // Preconditions: Model Number must be a string with 5 and only 5 characters.
        public string ModelNum
        {
            get
            {
                return _modelNum;
            }
            set
            {
                if (value.Length == 5)          // Model Number must be a string with 5 and only 5 characters. If not, default data is used.
                    _modelNum = value;
                else
                    _modelNum = MODEL_DEFAULT;
            }
        }
        // Postconditions: Model number is returned.

        // Property to hold service order's Serial Number. Validated in set assessor.
        // Preconditions: Serial Number must be a string with 10 and only 10 characters.
        public string SerialNum
        {
            get
            {
                return _serialNum;
            }
            set
            {
                if (value.Length == 10)         // Serial Number must be a string with 10 and only 10 characters. If not, default data is used.
                    _serialNum = value;
                else
                    _serialNum = SERIAL_DEFAULT;
            }
        }
        // Postconditions: Serial number is returned.

        // Property to hold service order's Technician Name. Validated in set assessor.
        // Preconditions: Technician Name must not be blank.
        public string TechName
        {
            get
            {
                return _techName;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))      // Technician Name must not be blank. If so, default data is used.
                    _techName = value;
                else
                    _techName = TECH_DEFAULT;
            }
        }
        // Postconditions: Technician Name is returned.

        // Property to hold service order's length of time in minutes. Validated in set assessor.
        // Preconditions: Appointment Mintues must be at least 15 minutes and no longer than 180 minutes.
        public int AppMinutes
        {
            get
            {
                return _appMinutes;
            }
            set
            {
                if (value >= TIME_MIN && value <= TIME_MAX)         // Appointment Mintues must be at least 15 minutes and no longer than 180 minutes. If not, default data is used.
                    _appMinutes = value;
                else
                    _appMinutes = TIME_DEFAULT;
            }
        }
        // Postconditions: Appointment minutes is returned.

        // Property to hold bool if order is under warranty or not.
        // Preconditions: Waranty is a boolean variable and must be true or false.
        public bool HasWarranty
        {
            get
            {
                return _hasWarranty;
            }
            set
            {
                _hasWarranty = value;
            }
        }
        // Postconditions: HasWarranty is now true or false.

        // Property to hold calculation of Appointment Hours from Appointment Minutes.
        // Only uses get accessor, transforms data from minutes before storing.
        // Preconditions: Appointment length in minutes has already been returned.
        public double AppHours
        {
            get
            {
                return _appMinutes / MINS_TO_HOURS;         // AppMinutes is divided by 60 to get App. Hours before it is returned.
            }
        }
        // Postconditions: Appointment length in hours is returned.

        // Property to hold calculation of order's cost.
        // Calculated and returned in seperate CalcCost method within this class.
        // Preconditions: AppMinutes and HasWarranty have already been returned.
        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                    _cost = value;
            }
        }
        // Postconditions: Cost of order is returned.

        // Overridden ToString method. Simplifies the display of each object's properties.
        // Preconditions: object is instantiated.
        public override string ToString()
        {
            return ("Service Location Zip Code: "+ZipCode+ Environment.NewLine +
                "Model Number: " + ModelNum + Environment.NewLine +
                "Serial Number: " + SerialNum + Environment.NewLine +
                "Appointment Length: " + AppMinutes  + Environment.NewLine +
                "Appointment Hours: " + AppHours + Environment.NewLine +
                "Technician Name: " + TechName + Environment.NewLine +
                "Warranty Coverage?: " + HasWarranty + Environment.NewLine +
                "Calculate Cost Output: " + Cost.ToString("C") + Environment.NewLine + Environment.NewLine);
        }
        // Postconditions: string for object returned.

        // CalcCost method. Called in DisplayServiceOrder method to calculate order's cost and return it to the Cost property of that object.
        // Preconditions: Object is instantiated.
        public double CalcCost()
        {
            double cost;
            if (HasWarranty)
                cost = WARRANTY_BASE_COST;
            else
                cost = NO_WARRANTY_BASE_COST + (FEE_PER_MIN * AppMinutes);
            return cost;
        }
        //Postconditions: Cost of order is returned.
    }
}
