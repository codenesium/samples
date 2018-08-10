using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALServerTaskMapper
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
    <Hash>9db33689598e1800e4978c7180baaf0a</Hash>
</Codenesium>*/