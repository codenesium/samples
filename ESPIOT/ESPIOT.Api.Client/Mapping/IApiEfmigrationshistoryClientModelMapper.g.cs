using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public partial interface IApiEfmigrationshistoryModelMapper
	{
		ApiEfmigrationshistoryClientResponseModel MapClientRequestToResponse(
			string migrationId,
			ApiEfmigrationshistoryClientRequestModel request);

		ApiEfmigrationshistoryClientRequestModel MapClientResponseToRequest(
			ApiEfmigrationshistoryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>43507a68a2375294b4485873b4f49a76</Hash>
</Codenesium>*/