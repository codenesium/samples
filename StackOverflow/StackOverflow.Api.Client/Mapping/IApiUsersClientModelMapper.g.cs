using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiUsersModelMapper
	{
		ApiUsersClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUsersClientRequestModel request);

		ApiUsersClientRequestModel MapClientResponseToRequest(
			ApiUsersClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>1b43318c093f50447d025ea8293409f6</Hash>
</Codenesium>*/