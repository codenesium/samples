using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALLinkTypesMapper
	{
		LinkTypes MapBOToEF(
			BOLinkTypes bo);

		BOLinkTypes MapEFToBO(
			LinkTypes efLinkTypes);

		List<BOLinkTypes> MapEFToBO(
			List<LinkTypes> records);
	}
}

/*<Codenesium>
    <Hash>a05a426b9288da12ffb472c16c604195</Hash>
</Codenesium>*/