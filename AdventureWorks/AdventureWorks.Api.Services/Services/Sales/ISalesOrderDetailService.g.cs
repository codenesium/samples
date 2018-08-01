using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ISalesOrderDetailService
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
    <Hash>cdeb2a95283dd43b9d39a492368dfe0c</Hash>
</Codenesium>*/