using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ILocationService
	{
		Task<CreateResponse<ApiLocationServerResponseModel>> Create(
			ApiLocationServerRequestModel model);

		Task<UpdateResponse<ApiLocationServerResponseModel>> Update(short locationID,
		                                                             ApiLocationServerRequestModel model);

		Task<ActionResponse> Delete(short locationID);

		Task<ApiLocationServerResponseModel> Get(short locationID);

		Task<List<ApiLocationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiLocationServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>e6f8daf6d5b0a32568e833f60a0c36f0</Hash>
</Codenesium>*/