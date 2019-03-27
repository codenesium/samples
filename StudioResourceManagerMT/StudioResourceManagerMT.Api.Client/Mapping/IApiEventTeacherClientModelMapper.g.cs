using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventTeacherModelMapper
	{
		ApiEventTeacherClientResponseModel MapClientRequestToResponse(
			int eventId,
			ApiEventTeacherClientRequestModel request);

		ApiEventTeacherClientRequestModel MapClientResponseToRequest(
			ApiEventTeacherClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5cae1a6330b4189797feceaa351a8acf</Hash>
</Codenesium>*/