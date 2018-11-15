using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLUserMapper
	{
		BOUser MapModelToBO(
			int id,
			ApiUserServerRequestModel model);

		ApiUserServerResponseModel MapBOToModel(
			BOUser boUser);

		List<ApiUserServerResponseModel> MapBOToModel(
			List<BOUser> items);
	}
}

/*<Codenesium>
    <Hash>78c89fc6a307c27c63f7535f901a94c4</Hash>
</Codenesium>*/