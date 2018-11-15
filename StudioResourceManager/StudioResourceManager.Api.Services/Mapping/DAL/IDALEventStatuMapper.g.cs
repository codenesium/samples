using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>145a094635913a7c1b2fa2217d2b8d6a</Hash>
</Codenesium>*/