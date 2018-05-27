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
		Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model);

		Task<ActionResponse> Update(int customerID,
		                            ApiCustomerRequestModel model);

		Task<ActionResponse> Delete(int customerID);

		Task<ApiCustomerResponseModel> Get(int customerID);

		Task<List<ApiCustomerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiCustomerResponseModel> GetAccountNumber(string accountNumber);
		Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID);
	}
}

/*<Codenesium>
    <Hash>01f69e1c6a7636b660a82e7f53468a26</Hash>
</Codenesium>*/