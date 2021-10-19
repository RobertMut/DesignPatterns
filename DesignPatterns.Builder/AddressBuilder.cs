using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class AddressBuilder : IAddressBuilder
    {
        private Address _address;
        private AddressBuilder()
        {
            _address = new Address();
        }

        public IAddressBuilder SetStreet(string street)
        {
            _address.Street = street;
            return this;
        }

        public IAddressBuilder SetHouseNumber(string houseNumber)
        {
            _address.HouseNumber = houseNumber;
            return this;
        }

        public IAddressBuilder SetApartmentNumber(int apartmentNumber)
        {
            _address.ApartmentNumber = apartmentNumber;
            return this;
        }

        public IAddressBuilder SetPostalCode(string postCode)
        {
            _address.PostalCode = postCode;
            return this;
        }

        public IAddressBuilder SetCity(string city)
        {
            _address.City = city;
            return this;
        }

        public Address Build() => _address;
        public static AddressBuilder Create() => new AddressBuilder();
    }

    public interface IAddressBuilder
    {
        IAddressBuilder SetStreet(string street);
        IAddressBuilder SetHouseNumber(string houseNumber);
        IAddressBuilder SetApartmentNumber(int apartmentNumber);
        IAddressBuilder SetPostalCode(string postCode);
        IAddressBuilder SetCity(string city);
        Address Build();
    }
}
