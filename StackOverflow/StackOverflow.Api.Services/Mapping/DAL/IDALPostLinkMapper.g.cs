using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostLinkMapper
	{
		PostLink MapBOToEF(
			BOPostLink bo);

		BOPostLink MapEFToBO(
			PostLink efPostLink);

		List<BOPostLink> MapEFToBO(
			List<PostLink> records);
	}
}

/*<Codenesium>
    <Hash>d7c9eb1d05b7a2712d8de43ffbe345cd</Hash>
</Codenesium>*/