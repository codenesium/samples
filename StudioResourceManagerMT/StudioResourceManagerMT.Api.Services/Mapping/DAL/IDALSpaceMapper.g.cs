using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALSpaceMapper
	{
		Space MapBOToEF(
			BOSpace bo);

		BOSpace MapEFToBO(
			Space efSpace);

		List<BOSpace> MapEFToBO(
			List<Space> records);
	}
}

/*<Codenesium>
    <Hash>b73739e8ae50b696885035241b6d9337</Hash>
</Codenesium>*/