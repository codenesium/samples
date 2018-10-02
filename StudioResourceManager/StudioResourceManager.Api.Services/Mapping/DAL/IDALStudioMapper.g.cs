using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>3cfe600643e7144dc4d44e60c53c349a</Hash>
</Codenesium>*/