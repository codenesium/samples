using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventStudentModelMapper
	{
		ApiEventStudentClientResponseModel MapClientRequestToResponse(
			int eventId,
			ApiEventStudentClientRequestModel request);

		ApiEventStudentClientRequestModel MapClientResponseToRequest(
			ApiEventStudentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4a18f1811d8505d75fd8853395260469</Hash>
</Codenesium>*/