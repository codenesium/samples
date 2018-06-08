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

                Task<List<Customer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Customer> GetAccountNumber(string accountNumber);
                Task<List<Customer>> GetTerritoryID(Nullable<int> territoryID);
        }
}

/*<Codenesium>
    <Hash>8eb93b07f2f46fe5e87584ddb316cfa1</Hash>
</Codenesium>*/