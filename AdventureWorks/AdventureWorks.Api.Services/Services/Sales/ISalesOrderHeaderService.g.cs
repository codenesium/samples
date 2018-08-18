using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesOrderHeaderService
	{
		Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model);

		Task<UpdateResponse<ApiSalesOrderHeaderResponseModel>> Update(int salesOrderID,
		                                                               ApiSalesOrderHeaderRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderHeaderResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesOrderHeaderResponseModel> BySalesOrderNumber(string salesOrderNumber);

		Task<List<ApiSalesOrderHeaderResponseModel>> ByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderResponseModel>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>39fde3e7f40f377cbb70335c7247189b</Hash>
</Codenesium>*/