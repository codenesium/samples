using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>42ba93c05fee71ee01b1ea98bcd521ba</Hash>
</Codenesium>*/