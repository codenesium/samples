using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiTeacherModelMapper
	{
		ApiTeacherClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherClientRequestModel request);

		ApiTeacherClientRequestModel MapClientResponseToRequest(
			ApiTeacherClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>be8228546f52277b3e9c8f12d67ee284</Hash>
</Codenesium>*/