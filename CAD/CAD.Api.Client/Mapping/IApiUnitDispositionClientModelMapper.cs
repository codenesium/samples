using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiUnitDispositionModelMapper
	{
		ApiUnitDispositionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUnitDispositionClientRequestModel request);

		ApiUnitDispositionClientRequestModel MapClientResponseToRequest(
			ApiUnitDispositionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>e2aeb9288574538bda4c726d49e0fa82</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/