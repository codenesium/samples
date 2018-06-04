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
    <Hash>af4d6c4792f6517ea8f66c24489c3bd9</Hash>
</Codenesium>*/