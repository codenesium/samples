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
			ApiFollowerRequestModel model);

		ApiFollowerResponseModel MapBOToModel(
			BOFollower boFollower);

		List<ApiFollowerResponseModel> MapBOToModel(
			List<BOFollower> items);
	}
}

/*<Codenesium>
    <Hash>0541f63d1c4736319a8c7b39c58476c8</Hash>
</Codenesium>*/