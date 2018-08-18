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
    <Hash>fe24575bfb647db7658edd10dfd297dd</Hash>
</Codenesium>*/