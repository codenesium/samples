using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IBusinessEntityAddressRepository
        {
                Task<BusinessEntityAddress> Create(BusinessEntityAddress item);

                Task Update(BusinessEntityAddress item);

                Task Delete(int businessEntityID);

                Task<BusinessEntityAddress> Get(int businessEntityID);

                Task<List<BusinessEntityAddress>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<BusinessEntityAddress>> GetAddressID(int addressID);
                Task<List<BusinessEntityAddress>> GetAddressTypeID(int addressTypeID);
        }
}

/*<Codenesium>
    <Hash>c877957c8b501c4cfd8207374510e6bf</Hash>
</Codenesium>*/