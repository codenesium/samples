using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALOctopusServerNodeMapper
	{
		OctopusServerNode MapBOToEF(
			BOOctopusServerNode bo);

		BOOctopusServerNode MapEFToBO(
			OctopusServerNode efOctopusServerNode);

		List<BOOctopusServerNode> MapEFToBO(
			List<OctopusServerNode> records);
	}
}

/*<Codenesium>
    <Hash>b94eb30c0edefc1b498375329e16b3cf</Hash>
</Codenesium>*/