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
			ApiRetweetServerRequestModel model);

		ApiRetweetServerResponseModel MapBOToModel(
			BORetweet boRetweet);

		List<ApiRetweetServerResponseModel> MapBOToModel(
			List<BORetweet> items);
	}
}

/*<Codenesium>
    <Hash>82fa97e5f433adf730682984a6787045</Hash>
</Codenesium>*/