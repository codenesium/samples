using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALVEventMapper
	{
		VEvent MapBOToEF(
			BOVEvent bo);

		BOVEvent MapEFToBO(
			VEvent efVEvent);

		List<BOVEvent> MapEFToBO(
			List<VEvent> records);
	}
}

/*<Codenesium>
    <Hash>828fbebebe09c0e0341df68511d50767</Hash>
</Codenesium>*/