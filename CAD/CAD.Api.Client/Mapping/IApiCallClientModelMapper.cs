using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallModelMapper
	{
		ApiCallClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallClientRequestModel request);

		ApiCallClientRequestModel MapClientResponseToRequest(
			ApiCallClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>06c2356889a6d033eb05c97e5456006c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/