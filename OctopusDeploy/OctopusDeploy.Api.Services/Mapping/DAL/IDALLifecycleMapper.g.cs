using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALLifecycleMapper
	{
		Lifecycle MapBOToEF(
			BOLifecycle bo);

		BOLifecycle MapEFToBO(
			Lifecycle efLifecycle);

		List<BOLifecycle> MapEFToBO(
			List<Lifecycle> records);
	}
}

/*<Codenesium>
    <Hash>e7953a588d94dae6f5b6cedae7faad14</Hash>
</Codenesium>*/