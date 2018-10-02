using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLQuoteTweetMapper
	{
		BOQuoteTweet MapModelToBO(
			int quoteTweetId,
			ApiQuoteTweetRequestModel model);

		ApiQuoteTweetResponseModel MapBOToModel(
			BOQuoteTweet boQuoteTweet);

		List<ApiQuoteTweetResponseModel> MapBOToModel(
			List<BOQuoteTweet> items);
	}
}

/*<Codenesium>
    <Hash>8298388a1b5c5b420e4c891dd3d58ab7</Hash>
</Codenesium>*/