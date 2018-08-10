using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesOrderDetailService
	{
		Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
			ApiSalesOrderDetailRequestModel model);

		Task<UpdateResponse<ApiSalesOrderDetailResponseModel>> Update(int salesOrderID,
		                                                               ApiSalesOrderDetailRequestModel model);

		Task<ActionResponse> Delete(int salesOrderID);

		Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID);

		Task<List<ApiSalesOrderDetailResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderDetailResponseModel>> ByProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>a06d3db83fd99c92594930abf7680803</Hash>
</Codenesium>*/