using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostTypeMapper
	{
		PostType MapBOToEF(
			BOPostType bo);

		BOPostType MapEFToBO(
			PostType efPostType);

		List<BOPostType> MapEFToBO(
			List<PostType> records);
	}
}

/*<Codenesium>
    <Hash>798e967bf2a42eb7795abf6c8bde2ff8</Hash>
</Codenesium>*/