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

		Task<POCOCustomer> Get(int customerID);

		Task<List<POCOCustomer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCustomer> GetAccountNumber(string accountNumber);
		Task<List<POCOCustomer>> GetTerritoryID(Nullable<int> territoryID);
	}
}

/*<Codenesium>
    <Hash>a05b3f562e7c395f294121e5ed4f8ed8</Hash>
</Codenesium>*/