using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALDirectTweetMapper
	{
		DirectTweet MapBOToEF(
			BODirectTweet bo);

		BODirectTweet MapEFToBO(
			DirectTweet efDirectTweet);

		List<BODirectTweet> MapEFToBO(
			List<DirectTweet> records);
	}
}

/*<Codenesium>
    <Hash>3993cf0a38ec09930bface056a5977b5</Hash>
</Codenesium>*/