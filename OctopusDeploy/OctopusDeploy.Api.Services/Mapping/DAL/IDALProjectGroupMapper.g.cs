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
    <Hash>cfc793d058114656a28d37be4db78019</Hash>
</Codenesium>*/