using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostTypeModelMapper
	{
		ApiPostTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostTypeClientRequestModel request);

		ApiPostTypeClientRequestModel MapClientResponseToRequest(
			ApiPostTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ebf780138c860623374e5ec75eaed95c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/