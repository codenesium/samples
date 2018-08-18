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
    <Hash>06b9a7051514f2b8dac00e31901e2932</Hash>
</Codenesium>*/