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
    <Hash>a670d0f2738a145547349b457db62022</Hash>
</Codenesium>*/