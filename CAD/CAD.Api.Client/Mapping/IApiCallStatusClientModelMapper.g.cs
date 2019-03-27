using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallStatusModelMapper
	{
		ApiCallStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallStatusClientRequestModel request);

		ApiCallStatusClientRequestModel MapClientResponseToRequest(
			ApiCallStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>8fae9d1edead927d15a463f319dbe674</Hash>
</Codenesium>*/