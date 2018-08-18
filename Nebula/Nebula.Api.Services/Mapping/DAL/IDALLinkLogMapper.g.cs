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
    <Hash>d8a8e7dafa8174110406025a1b9c69ba</Hash>
</Codenesium>*/