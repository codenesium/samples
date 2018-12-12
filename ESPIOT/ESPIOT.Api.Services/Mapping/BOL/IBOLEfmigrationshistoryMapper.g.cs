using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
	public partial interface IBOLEfmigrationshistoryMapper
	{
		BOEfmigrationshistory MapModelToBO(
			string migrationId,
			ApiEfmigrationshistoryServerRequestModel model);

		ApiEfmigrationshistoryServerResponseModel MapBOToModel(
			BOEfmigrationshistory boEfmigrationshistory);

		List<ApiEfmigrationshistoryServerResponseModel> MapBOToModel(
			List<BOEfmigrationshistory> items);
	}
}

/*<Codenesium>
    <Hash>613b8f3086511889ca7eaa6a07f55158</Hash>
</Codenesium>*/