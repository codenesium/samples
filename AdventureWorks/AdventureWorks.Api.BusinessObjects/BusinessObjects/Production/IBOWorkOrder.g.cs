using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOWorkOrder
	{
		Task<CreateResponse<ApiWorkOrderResponseModel>> Create(
			ApiWorkOrderRequestModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            ApiWorkOrderRequestModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<ApiWorkOrderResponseModel> Get(int workOrderID);

		Task<List<ApiWorkOrderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiWorkOrderResponseModel>> GetProductID(int productID);
		Task<List<ApiWorkOrderResponseModel>> GetScrapReasonID(Nullable<short> scrapReasonID);
	}
}

/*<Codenesium>
    <Hash>9e2e63748a1f5903525a7b8e1cfd2e7b</Hash>
</Codenesium>*/