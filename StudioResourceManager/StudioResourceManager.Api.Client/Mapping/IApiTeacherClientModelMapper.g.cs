using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>711bf0a236eb6ccaa4ddea2e71971497</Hash>
</Codenesium>*/