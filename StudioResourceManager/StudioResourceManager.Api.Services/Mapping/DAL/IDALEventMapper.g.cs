using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALEventMapper
	{
		Event MapBOToEF(
			BOEvent bo);

		BOEvent MapEFToBO(
			Event efEvent);

		List<BOEvent> MapEFToBO(
			List<Event> records);
	}
}

/*<Codenesium>
    <Hash>debaea1be5e84f5622be258554028688</Hash>
</Codenesium>*/