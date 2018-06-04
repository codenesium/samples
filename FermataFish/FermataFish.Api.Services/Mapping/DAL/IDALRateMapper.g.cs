using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IDALRateMapper
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
    <Hash>1194ee221c7addd2d8a320d26f1086d4</Hash>
</Codenesium>*/