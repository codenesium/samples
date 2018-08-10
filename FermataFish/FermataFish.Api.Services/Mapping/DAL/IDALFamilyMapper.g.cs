using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALFamilyMapper
	{
		Family MapBOToEF(
			BOFamily bo);

		BOFamily MapEFToBO(
			Family efFamily);

		List<BOFamily> MapEFToBO(
			List<Family> records);
	}
}

/*<Codenesium>
    <Hash>285ce9f86108d4ebc93f6210688ba7fd</Hash>
</Codenesium>*/