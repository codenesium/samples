using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>efbbfd491f18a0045c4e25828277b83e</Hash>
</Codenesium>*/