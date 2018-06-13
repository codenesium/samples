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

                Task<List<AddressType>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<AddressType> GetName(string name);

                Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int addressTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fbfc232c30688a352b4d2d0201ad8d8b</Hash>
</Codenesium>*/