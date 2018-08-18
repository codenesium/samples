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
    <Hash>6bbc64f5c5303457b8fc98b43b98478b</Hash>
</Codenesium>*/