using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALTweetMapper
	{
		Tweet MapBOToEF(
			BOTweet bo);

		BOTweet MapEFToBO(
			Tweet efTweet);

		List<BOTweet> MapEFToBO(
			List<Tweet> records);
	}
}

/*<Codenesium>
    <Hash>85110bf8704eac7dfa9fe74f20cfbc02</Hash>
</Codenesium>*/