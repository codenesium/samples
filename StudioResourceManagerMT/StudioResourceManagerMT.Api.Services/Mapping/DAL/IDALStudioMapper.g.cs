using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALStudioMapper
	{
		Studio MapBOToEF(
			BOStudio bo);

		BOStudio MapEFToBO(
			Studio efStudio);

		List<BOStudio> MapEFToBO(
			List<Studio> records);
	}
}

/*<Codenesium>
    <Hash>110439e50679f9bcc417ac5a55bdfdf0</Hash>
</Codenesium>*/