using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCustomer
	{
		Task<CreateResponse<POCOCustomer>> Create(
			ApiCustomerModel model);

		Task<ActionResponse> Update(int customerID,
		                            ApiCustomerModel model);

		Task<ActionResponse> Delete(int customerID);

		POCOCustomer Get(int customerID);

		List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCustomer GetAccountNumber(string accountNumber);

		List<POCOCustomer> GetTerritoryID(Nullable<int> territoryID);
	}
}

/*<Codenesium>
    <Hash>3f42863e522d0410d76d06c9e103df45</Hash>
</Codenesium>*/