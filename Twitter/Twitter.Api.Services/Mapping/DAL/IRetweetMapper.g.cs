using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALRetweetMapper
	{
		Retweet MapModelToEntity(
			int id,
			ApiRetweetServerRequestModel model);

		ApiRetweetServerResponseModel MapEntityToModel(
			Retweet item);

		List<ApiRetweetServerResponseModel> MapEntityToModel(
			List<Retweet> items);
	}
}

/*<Codenesium>
    <Hash>195dde8ea655bc9b3703f7552551d414</Hash>
</Codenesium>*/