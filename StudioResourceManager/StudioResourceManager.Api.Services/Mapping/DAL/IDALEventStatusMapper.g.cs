using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALEventStatusMapper
	{
		EventStatus MapBOToEF(
			BOEventStatus bo);

		BOEventStatus MapEFToBO(
			EventStatus efEventStatus);

		List<BOEventStatus> MapEFToBO(
			List<EventStatus> records);
	}
}

/*<Codenesium>
    <Hash>da17e19aee4bb68c3d60859d0916a9ba</Hash>
</Codenesium>*/