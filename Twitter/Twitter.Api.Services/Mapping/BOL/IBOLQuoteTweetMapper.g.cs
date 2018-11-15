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
			ApiQuoteTweetServerRequestModel model);

		ApiQuoteTweetServerResponseModel MapBOToModel(
			BOQuoteTweet boQuoteTweet);

		List<ApiQuoteTweetServerResponseModel> MapBOToModel(
			List<BOQuoteTweet> items);
	}
}

/*<Codenesium>
    <Hash>d2504f3575b66a1e8b83a4f8e72da2a2</Hash>
</Codenesium>*/