using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkLogMapper
	{
		LinkLog MapBOToEF(
			BOLinkLog bo);

		BOLinkLog MapEFToBO(
			LinkLog efLinkLog);

		List<BOLinkLog> MapEFToBO(
			List<LinkLog> records);
	}
}

/*<Codenesium>
    <Hash>cfe68c78fabbcbe7c20900fed738a5b0</Hash>
</Codenesium>*/