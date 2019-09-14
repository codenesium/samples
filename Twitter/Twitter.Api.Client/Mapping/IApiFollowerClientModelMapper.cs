using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
{
	public partial interface IApiFollowerModelMapper
	{
		ApiFollowerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFollowerClientRequestModel request);

		ApiFollowerClientRequestModel MapClientResponseToRequest(
			ApiFollowerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2175a936489e61fa38d21f7d95119d51</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/