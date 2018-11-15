using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiOrganizationModelMapper
	{
		ApiOrganizationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOrganizationClientRequestModel request);

		ApiOrganizationClientRequestModel MapClientResponseToRequest(
			ApiOrganizationClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>28aef75aec574d763cd23ef52eed5221</Hash>
</Codenesium>*/