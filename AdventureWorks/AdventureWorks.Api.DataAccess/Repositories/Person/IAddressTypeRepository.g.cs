using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IAddressTypeRepository
        {
                Task<AddressType> Create(AddressType item);

                Task Update(AddressType item);

                Task Delete(int addressTypeID);

                Task<AddressType> Get(int addressTypeID);

                Task<List<AddressType>> All(int limit = int.MaxValue, int offset = 0);

                Task<AddressType> ByName(string name);

                Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int addressTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7a97772e3a0212ee312a7757907cc2f6</Hash>
</Codenesium>*/