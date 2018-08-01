using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALPostLinksMapper
	{
		PostLinks MapBOToEF(
			BOPostLinks bo);

		BOPostLinks MapEFToBO(
			PostLinks efPostLinks);

		List<BOPostLinks> MapEFToBO(
			List<PostLinks> records);
	}
}

/*<Codenesium>
    <Hash>836f48df3f80d3e60e08c8a57ff08ea5</Hash>
</Codenesium>*/