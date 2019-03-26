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

		Task<List<ApiLocationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiLocationServerResponseModel> ByName(string name);
	}
}

/*<Codenesium>
    <Hash>6798098981fc91f2ed24eed07241157f</Hash>
</Codenesium>*/