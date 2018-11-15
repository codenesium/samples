using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesOrderHeaderService
	{
		Task<CreateResponse<ApiSalesOrderHeaderServerResponseModel>> Create(
			ApiSalesOrderHeaderServerRequestModel model);

		Task<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>> Update(int salesOrderID,
		                                                                     ApiSalesOrderHeaderServerRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderHeaderServerResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesOrderHeaderServerResponseModel> ByRowguid(Guid rowguid);

		Task<ApiSalesOrderHeaderServerResponseModel> BySalesOrderNumber(string salesOrderNumber);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> ByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c123d9998b6576b23eb0f8022a064294</Hash>
</Codenesium>*/