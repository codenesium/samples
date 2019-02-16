using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALFollowingMapper
	{
		Following MapModelToEntity(
			int userId,
			ApiFollowingServerRequestModel model);

		ApiFollowingServerResponseModel MapEntityToModel(
			Following item);

		List<ApiFollowingServerResponseModel> MapEntityToModel(
			List<Following> items);
	}
}

/*<Codenesium>
    <Hash>d27cf6afacc4e02a5ce5ef94b2f6bc2b</Hash>
</Codenesium>*/