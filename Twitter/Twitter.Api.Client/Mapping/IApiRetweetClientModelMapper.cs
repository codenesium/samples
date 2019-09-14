using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
{
	public partial interface IApiRetweetModelMapper
	{
		ApiRetweetClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRetweetClientRequestModel request);

		ApiRetweetClientRequestModel MapClientResponseToRequest(
			ApiRetweetClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>6fdf560d4ae6810c8a569a6e8c968ceb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/