using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
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
    <Hash>b065d4046733b972f2cf499b4f887da8</Hash>
</Codenesium>*/