using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ILocationService
	{
		Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model);

		Task<UpdateResponse<ApiLocationResponseModel>> Update(short locationID,
		                                                       ApiLocationRequestModel model);

		Task<ActionResponse> Delete(short locationID);

		Task<ApiLocationResponseModel> Get(short locationID);

		Task<List<ApiLocationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLocationResponseModel> ByName(string name);

		Task<List<ApiProductInventoryResponseModel>> ProductInventoriesByLocationID(short locationID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingsByLocationID(short locationID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1008364e5bde57ec3f4349adf13b283f</Hash>
</Codenesium>*/