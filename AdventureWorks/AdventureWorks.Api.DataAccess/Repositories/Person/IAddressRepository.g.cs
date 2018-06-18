using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IAddressRepository
        {
                Task<Address> Create(Address item);

                Task Update(Address item);

                Task Delete(int addressID);

                Task<Address> Get(int addressID);

                Task<List<Address>> All(int limit = int.MaxValue, int offset = 0);

                Task<Address> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);
                Task<List<Address>> ByStateProvinceID(int stateProvinceID);

                Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b8e70b727d2e9f4598032359f72bbccf</Hash>
</Codenesium>*/