using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>5efe2810041d9f43574f8a870e78eed1</Hash>
</Codenesium>*/