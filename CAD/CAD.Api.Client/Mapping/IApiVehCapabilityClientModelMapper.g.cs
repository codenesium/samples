using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehCapabilityModelMapper
	{
		ApiVehCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehCapabilityClientRequestModel request);

		ApiVehCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5cf773790efc06cf5b207c1292012ba0</Hash>
</Codenesium>*/