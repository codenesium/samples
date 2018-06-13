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

                Task<List<Address>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Address> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);
                Task<List<Address>> GetStateProvinceID(int stateProvinceID);

                Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c97a4d0854ef30b007a53a7fb3229deb</Hash>
</Codenesium>*/