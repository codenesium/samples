using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>44c84f05ea16cf0c77e8e704a380475b</Hash>
</Codenesium>*/