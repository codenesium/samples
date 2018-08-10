using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALProjectGroupMapper
	{
		ProjectGroup MapBOToEF(
			BOProjectGroup bo);

		BOProjectGroup MapEFToBO(
			ProjectGroup efProjectGroup);

		List<BOProjectGroup> MapEFToBO(
			List<ProjectGroup> records);
	}
}

/*<Codenesium>
    <Hash>40148018959e284a19bc874ae0e1ae38</Hash>
</Codenesium>*/