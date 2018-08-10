using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALProjectMapper
	{
		Project MapBOToEF(
			BOProject bo);

		BOProject MapEFToBO(
			Project efProject);

		List<BOProject> MapEFToBO(
			List<Project> records);
	}
}

/*<Codenesium>
    <Hash>8f2ea0ce7e6cede9de681ca60039cb18</Hash>
</Codenesium>*/