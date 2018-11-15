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

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiCustomerServerResponseModel> ByAccountNumber(string accountNumber);

		Task<ApiCustomerServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiCustomerServerResponseModel>> ByTerritoryID(int? territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>91989ba8aae7970e8e4a749959deeda2</Hash>
</Codenesium>*/