using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ICustomerService
	{
		Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model);

		Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(int customerID,
		                                                             ApiCustomerServerRequestModel model);

		Task<ActionResponse> Delete(int customerID);

		Task<ApiCustomerServerResponseModel> Get(int customerID);

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiCustomerServerResponseModel> ByAccountNumber(string accountNumber);

		Task<ApiCustomerServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiCustomerServerResponseModel>> ByTerritoryID(int? territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a0adb07114663b5f5e9c947e8f65b7ee</Hash>
</Codenesium>*/