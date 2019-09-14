using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALQuoteTweetMapper
	{
		QuoteTweet MapModelToEntity(
			int quoteTweetId,
			ApiQuoteTweetServerRequestModel model);

		ApiQuoteTweetServerResponseModel MapEntityToModel(
			QuoteTweet item);

		List<ApiQuoteTweetServerResponseModel> MapEntityToModel(
			List<QuoteTweet> items);
	}
}

/*<Codenesium>
    <Hash>d0c0331824ee5861ca58cec6abb5d001</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/