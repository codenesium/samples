using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ICustomerRepository
        {
                Task<Customer> Create(Customer item);

                Task Update(Customer item);

                Task Delete(int customerID);

                Task<Customer> Get(int customerID);

                Task<List<Customer>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Customer> GetAccountNumber(string accountNumber);
                Task<List<Customer>> GetTerritoryID(Nullable<int> territoryID);

                Task<List<SalesOrderHeader>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>16421b558799c06d56c196744c6da3a1</Hash>
</Codenesium>*/