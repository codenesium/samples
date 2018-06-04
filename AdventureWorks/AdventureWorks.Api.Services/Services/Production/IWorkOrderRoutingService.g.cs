using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IWorkOrderRoutingService
	{
		Task<CreateResponse<ApiWorkOrderRoutingResponseModel>> Create(
			ApiWorkOrderRoutingRequestModel model);

		Task<ActionResponse> Update(int workOrderID,
		                            ApiWorkOrderRoutingRequestModel model);

		Task<ActionResponse> Delete(int workOrderID);

		Task<ApiWorkOrderRoutingResponseModel> Get(int workOrderID);

		Task<List<ApiWorkOrderRoutingResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiWorkOrderRoutingResponseModel>> GetProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>c675450c6a919dcff6a604fad6bacb6f</Hash>
</Codenesium>*/