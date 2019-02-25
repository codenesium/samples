using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiAWBuildVersionModelMapper
	{
		ApiAWBuildVersionClientResponseModel MapClientRequestToResponse(
			int systemInformationID,
			ApiAWBuildVersionClientRequestModel request);

		ApiAWBuildVersionClientRequestModel MapClientResponseToRequest(
			ApiAWBuildVersionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a9004fdd5ecd8e9a701e76339f80c078</Hash>
</Codenesium>*/