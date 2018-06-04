using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>98b1ece9a4dc20dab929cca02f000fff</Hash>
</Codenesium>*/