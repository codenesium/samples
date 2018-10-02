using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALRetweetMapper
	{
		Retweet MapBOToEF(
			BORetweet bo);

		BORetweet MapEFToBO(
			Retweet efRetweet);

		List<BORetweet> MapEFToBO(
			List<Retweet> records);
	}
}

/*<Codenesium>
    <Hash>10183b4df7209b19000c65739fd331ad</Hash>
</Codenesium>*/