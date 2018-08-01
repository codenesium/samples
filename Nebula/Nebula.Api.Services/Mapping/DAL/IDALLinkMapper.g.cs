using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IDALLinkMapper
	{
		Link MapBOToEF(
			BOLink bo);

		BOLink MapEFToBO(
			Link efLink);

		List<BOLink> MapEFToBO(
			List<Link> records);
	}
}

/*<Codenesium>
    <Hash>cb160b046489a8d9689cd4ca20e7afce</Hash>
</Codenesium>*/