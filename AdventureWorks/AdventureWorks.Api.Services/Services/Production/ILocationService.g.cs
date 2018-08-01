using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface ILocationService
	{
		Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model);

		Task<UpdateResponse<ApiLocationResponseModel>> Update(short locationID,
		                                                       ApiLocationRequestModel model);

		Task<ActionResponse> Delete(short locationID);

		Task<ApiLocationResponseModel> Get(short locationID);

		Task<List<ApiLocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLocationResponseModel> ByName(string name);

		Task<List<ApiProductInventoryResponseModel>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ce11cd6a54b78ab3c4b23c48bd44f5df</Hash>
</Codenesium>*/