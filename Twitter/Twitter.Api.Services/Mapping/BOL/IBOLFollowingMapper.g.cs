using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLFollowingMapper
	{
		BOFollowing MapModelToBO(
			string userId,
			ApiFollowingRequestModel model);

		ApiFollowingResponseModel MapBOToModel(
			BOFollowing boFollowing);

		List<ApiFollowingResponseModel> MapBOToModel(
			List<BOFollowing> items);
	}
}

/*<Codenesium>
    <Hash>479aa01694b713808bb343531c18e4b8</Hash>
</Codenesium>*/