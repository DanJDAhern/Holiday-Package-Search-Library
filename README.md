
# Holiday Package Search Library

A small C# .NET library created to compare package holiday deals based on various data the user inputs via parsing JSON files.

The program will take a list of a user's requirements and query against the supplement JSON files to match possible combinations of flight and hotel based on the user's departure date.

The program also contains a handful of sample unit tests, designed to demonstrate knowledge of unit testing.

# Dependencies 

This program utilises the following NuGet packages:

**Newtonsoft** - For JSON parsing. \
**XUnit** - Framework for unit testing. 

# Example Input

The program does not contain console-based input, but relies on data being fed in the following way:

var holidaySearch = new HolidaySearch([Departure Airport], [Arrival Airport], [Departure Date], [Length of Stay]);

Exception handling is in place to alert you when there's an issue with an element of your query.

