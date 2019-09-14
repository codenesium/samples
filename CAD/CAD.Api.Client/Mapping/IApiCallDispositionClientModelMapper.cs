using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiCallDispositionModelMapper
	{
		ApiCallDispositionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallDispositionClientRequestModel request);

		ApiCallDispositionClientRequestModel MapClientResponseToRequest(
			ApiCallDispositionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>39fbb7a9c8c7b452d91ca5313e69672b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/