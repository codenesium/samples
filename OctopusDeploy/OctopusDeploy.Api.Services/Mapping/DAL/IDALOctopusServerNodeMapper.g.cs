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
    <Hash>fa50af643d98cf89a4538d58723b2b18</Hash>
</Codenesium>*/