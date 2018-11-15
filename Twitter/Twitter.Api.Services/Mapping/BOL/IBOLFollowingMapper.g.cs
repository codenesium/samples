using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLFollowingMapper
	{
		BOFollowing MapModelToBO(
			int userId,
			ApiFollowingServerRequestModel model);

		ApiFollowingServerResponseModel MapBOToModel(
			BOFollowing boFollowing);

		List<ApiFollowingServerResponseModel> MapBOToModel(
			List<BOFollowing> items);
	}
}

/*<Codenesium>
    <Hash>885cca9a1f2170c800e1b63c5cd295d6</Hash>
</Codenesium>*/