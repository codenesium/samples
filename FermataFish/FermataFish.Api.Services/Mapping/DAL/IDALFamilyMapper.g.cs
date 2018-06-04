using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IDALFamilyMapper
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
    <Hash>ce299d65e21d71d7177dea4bffdef979</Hash>
</Codenesium>*/