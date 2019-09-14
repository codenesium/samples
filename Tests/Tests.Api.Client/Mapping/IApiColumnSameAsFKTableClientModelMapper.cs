using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
{
	public partial interface IApiColumnSameAsFKTableModelMapper
	{
		ApiColumnSameAsFKTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiColumnSameAsFKTableClientRequestModel request);

		ApiColumnSameAsFKTableClientRequestModel MapClientResponseToRequest(
			ApiColumnSameAsFKTableClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1d8de22b850f5aa3b079e51c5755a146</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/