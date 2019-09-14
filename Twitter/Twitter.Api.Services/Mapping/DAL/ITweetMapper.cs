using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALTweetMapper
	{
		Tweet MapModelToEntity(
			int tweetId,
			ApiTweetServerRequestModel model);

		ApiTweetServerResponseModel MapEntityToModel(
			Tweet item);

		List<ApiTweetServerResponseModel> MapEntityToModel(
			List<Tweet> items);
	}
}

/*<Codenesium>
    <Hash>a4b14c9285404edd308d3d5952b6e42c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/