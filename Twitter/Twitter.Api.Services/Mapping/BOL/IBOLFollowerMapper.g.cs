using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLFollowerMapper
	{
		BOFollower MapModelToBO(
			int id,
			ApiFollowerServerRequestModel model);

		ApiFollowerServerResponseModel MapBOToModel(
			BOFollower boFollower);

		List<ApiFollowerServerResponseModel> MapBOToModel(
			List<BOFollower> items);
	}
}

/*<Codenesium>
    <Hash>3ed6916ff4a61b2c0dba0fc0fc038c00</Hash>
</Codenesium>*/