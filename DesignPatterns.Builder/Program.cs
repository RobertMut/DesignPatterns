using System;

namespace DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = AddressBuilder.Create()
                .SetStreet("Street")
                .SetHouseNumber("15/17")
                .SetApartmentNumber(3)
                .SetCity("City")
                .SetPostalCode("15555")
                .Build();
            Console.WriteLine($"Address: {address.Street} {address.HouseNumber} {address.ApartmentNumber}\r\n" +
                              $"{address.City} {address.PostalCode}");
        }
    }
}
