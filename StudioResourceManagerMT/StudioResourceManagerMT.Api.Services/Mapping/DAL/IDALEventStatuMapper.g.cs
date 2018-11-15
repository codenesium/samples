using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALEventStatuMapper
	{
		EventStatu MapBOToEF(
			BOEventStatu bo);

		BOEventStatu MapEFToBO(
			EventStatu efEventStatu);

		List<BOEventStatu> MapEFToBO(
			List<EventStatu> records);
	}
}

/*<Codenesium>
    <Hash>00788847d4dfd27e33258a816bc72fd2</Hash>
</Codenesium>*/