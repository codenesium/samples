using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiBadgeModelMapper
	{
		ApiBadgeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBadgeClientRequestModel request);

		ApiBadgeClientRequestModel MapClientResponseToRequest(
			ApiBadgeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>86e6c75a9e36d654fee666a3e4258dec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/