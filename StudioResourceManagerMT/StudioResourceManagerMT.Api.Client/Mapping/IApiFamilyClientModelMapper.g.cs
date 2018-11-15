using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>2779349a2dc289a01749d3715505ad4d</Hash>
</Codenesium>*/