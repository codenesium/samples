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

		Task<List<ApiSalesOrderDetailResponseModel>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>29b451560b962306cb26148f65a25bfc</Hash>
</Codenesium>*/