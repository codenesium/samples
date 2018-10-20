using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesReasonService
	{
		Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
			ApiSalesReasonRequestModel model);

		Task<UpdateResponse<ApiSalesReasonResponseModel>> Update(int salesReasonID,
		                                                          ApiSalesReasonRequestModel model);

		Task<ActionResponse> Delete(int salesReasonID);

		Task<ApiSalesReasonResponseModel> Get(int salesReasonID);

		Task<List<ApiSalesReasonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesReasonResponseModel>> BySalesOrderID(int salesReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7e98d47957a0099752e4ea154368a3f9</Hash>
</Codenesium>*/