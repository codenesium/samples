using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IDALLinkLogMapper
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
    <Hash>7849de16a42a5e0da64a0091bfbd955d</Hash>
</Codenesium>*/