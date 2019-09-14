using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiTagModelMapper
	{
		ApiTagClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTagClientRequestModel request);

		ApiTagClientRequestModel MapClientResponseToRequest(
			ApiTagClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>9a22466fe00357ac0de9e3eda8881050</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/