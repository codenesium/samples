using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALProjectMapper
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
    <Hash>e2589a9be9107d45b2cbb08e3bb31a74</Hash>
</Codenesium>*/