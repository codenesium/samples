using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALOctopusServerNodeMapper
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
    <Hash>eddde19489cd4a0c93f1b929692f78cb</Hash>
</Codenesium>*/