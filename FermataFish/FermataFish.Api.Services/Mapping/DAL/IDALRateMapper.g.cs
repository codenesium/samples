using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
    <Hash>ab1aebf5e4813dc69bb3c37ffbbcc6c1</Hash>
</Codenesium>*/