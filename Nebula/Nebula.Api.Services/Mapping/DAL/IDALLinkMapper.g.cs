using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkMapper
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
    <Hash>d9575ec9446dd525f009de89ae1da400</Hash>
</Codenesium>*/