using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICustomerRepository
	{
		Task<DTOCustomer> Create(DTOCustomer dto);

		Task Update(int customerID,
		            DTOCustomer dto);

		Task Delete(int customerID);

		Task<DTOCustomer> Get(int customerID);

		Task<List<DTOCustomer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOCustomer> GetAccountNumber(string accountNumber);
		Task<List<DTOCustomer>> GetTerritoryID(Nullable<int> territoryID);
	}
}

/*<Codenesium>
    <Hash>45c9081a6df8544123723cecd2572430</Hash>
</Codenesium>*/