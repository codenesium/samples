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
    <Hash>b74c459606bb52e06938d733aeca114b</Hash>
</Codenesium>*/