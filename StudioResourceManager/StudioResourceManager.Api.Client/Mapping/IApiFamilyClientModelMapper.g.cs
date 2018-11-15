using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiFamilyModelMapper
	{
		ApiFamilyClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFamilyClientRequestModel request);

		ApiFamilyClientRequestModel MapClientResponseToRequest(
			ApiFamilyClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1891275623d80deb17aa16bd6c7c854e</Hash>
</Codenesium>*/