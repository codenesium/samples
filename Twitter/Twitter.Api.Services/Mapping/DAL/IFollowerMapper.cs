using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALFollowerMapper
	{
		Follower MapModelToEntity(
			int id,
			ApiFollowerServerRequestModel model);

		ApiFollowerServerResponseModel MapEntityToModel(
			Follower item);

		List<ApiFollowerServerResponseModel> MapEntityToModel(
			List<Follower> items);
	}
}

/*<Codenesium>
    <Hash>f6a6755ab8ab3365f5f7251db3bcdd2a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/