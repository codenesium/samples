using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALProjectGroupMapper
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
    <Hash>43e8a5eecd583ee9add4f58d128387ff</Hash>
</Codenesium>*/