using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface ICustomerService
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
    <Hash>ce5600a4c76d5efcaeeb7eea5fa9e7e5</Hash>
</Codenesium>*/