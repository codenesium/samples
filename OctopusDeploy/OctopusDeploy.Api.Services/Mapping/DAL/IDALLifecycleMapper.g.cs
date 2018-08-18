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
    <Hash>6ac72efb1d06ad2a71d26571f44c008e</Hash>
</Codenesium>*/