using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALRateMapper
	{
		Rate MapBOToEF(
			BORate bo);

		BORate MapEFToBO(
			Rate efRate);

		List<BORate> MapEFToBO(
			List<Rate> records);
	}
}

/*<Codenesium>
    <Hash>7cf79139a07f080279fe7e7cf8d89546</Hash>
</Codenesium>*/