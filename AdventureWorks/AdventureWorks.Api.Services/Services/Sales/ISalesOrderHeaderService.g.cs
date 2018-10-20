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

		Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetailsBySalesOrderID(int salesOrderID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderResponseModel>> BySalesReasonID(int salesOrderID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7a7b6952e967bb9e6cc0eb5c4b0411fd</Hash>
</Codenesium>*/