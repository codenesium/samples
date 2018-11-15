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

		Task<List<ApiAWBuildVersionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bd9ef6471d707d21b63a3087cefa9652</Hash>
</Codenesium>*/