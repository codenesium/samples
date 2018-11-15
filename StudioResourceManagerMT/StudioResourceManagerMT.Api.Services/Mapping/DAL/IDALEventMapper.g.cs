using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>b31b4a8072b361a7c4dbf8f139b5f856</Hash>
</Codenesium>*/