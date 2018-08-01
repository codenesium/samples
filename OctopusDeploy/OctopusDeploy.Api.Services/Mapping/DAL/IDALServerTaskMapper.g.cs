using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALServerTaskMapper
	{
		ServerTask MapBOToEF(
			BOServerTask bo);

		BOServerTask MapEFToBO(
			ServerTask efServerTask);

		List<BOServerTask> MapEFToBO(
			List<ServerTask> records);
	}
}

/*<Codenesium>
    <Hash>ac0bdabd66f95403d3a83a0cc81f90d7</Hash>
</Codenesium>*/