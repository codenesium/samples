using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

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
    <Hash>edfd6ec5104727d7c7b8931507c5715c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/