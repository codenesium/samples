using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLRetweetMapper
	{
		BORetweet MapModelToBO(
			int id,
			ApiRetweetRequestModel model);

		ApiRetweetResponseModel MapBOToModel(
			BORetweet boRetweet);

		List<ApiRetweetResponseModel> MapBOToModel(
			List<BORetweet> items);
	}
}

/*<Codenesium>
    <Hash>e954d5ba723b199fb3b656e6b3c9b6b2</Hash>
</Codenesium>*/