using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALQuoteTweetMapper
	{
		QuoteTweet MapBOToEF(
			BOQuoteTweet bo);

		BOQuoteTweet MapEFToBO(
			QuoteTweet efQuoteTweet);

		List<BOQuoteTweet> MapEFToBO(
			List<QuoteTweet> records);
	}
}

/*<Codenesium>
    <Hash>58db4e752cbf83bc658f250ad2c0ab6f</Hash>
</Codenesium>*/