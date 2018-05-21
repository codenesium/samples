using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICustomerRepository
	{
		Task<POCOCustomer> Create(ApiCustomerModel model);

		Task Update(int customerID,
		            ApiCustomerModel model);

		Task Delete(int customerID);

		Task<POCOCustomer> Get(int customerID);

		Task<List<POCOCustomer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCustomer> GetAccountNumber(string accountNumber);
		Task<List<POCOCustomer>> GetTerritoryID(Nullable<int> territoryID);
	}
}

/*<Codenesium>
    <Hash>e65ccf00fa759ff252f5631cb9686170</Hash>
</Codenesium>*/