using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALLinkTypeMapper
	{
		LinkType MapBOToEF(
			BOLinkType bo);

		BOLinkType MapEFToBO(
			LinkType efLinkType);

		List<BOLinkType> MapEFToBO(
			List<LinkType> records);
	}
}

/*<Codenesium>
    <Hash>7c0802fa941db7db792a947932cb2e43</Hash>
</Codenesium>*/