using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IAWBuildVersionService
	{
		Task<CreateResponse<ApiAWBuildVersionServerResponseModel>> Create(
			ApiAWBuildVersionServerRequestModel model);

		Task<UpdateResponse<ApiAWBuildVersionServerResponseModel>> Update(int systemInformationID,
		                                                                   ApiAWBuildVersionServerRequestModel model);

		Task<ActionResponse> Delete(int systemInformationID);

		Task<ApiAWBuildVersionServerResponseModel> Get(int systemInformationID);

		Task<List<ApiAWBuildVersionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>2192e0abf637d84a342fb5251fa26c8b</Hash>
</Codenesium>*/