using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiSelfReferenceModelMapper
	{
		ApiSelfReferenceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSelfReferenceClientRequestModel request);

		ApiSelfReferenceClientRequestModel MapClientResponseToRequest(
			ApiSelfReferenceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4956aa27c1e514fa167058a8c59b8427</Hash>
</Codenesium>*/