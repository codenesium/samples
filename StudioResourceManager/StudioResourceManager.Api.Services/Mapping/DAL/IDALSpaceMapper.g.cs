using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALSpaceMapper
	{
		Space MapBOToEF(
			BOSpace bo);

		BOSpace MapEFToBO(
			Space efSpace);

		List<BOSpace> MapEFToBO(
			List<Space> records);
	}
}

/*<Codenesium>
    <Hash>03a80001c76cd85dafdbed907fff110b</Hash>
</Codenesium>*/