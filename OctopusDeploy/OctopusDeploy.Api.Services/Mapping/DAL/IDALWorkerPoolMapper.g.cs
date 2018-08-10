using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALWorkerPoolMapper
	{
		WorkerPool MapBOToEF(
			BOWorkerPool bo);

		BOWorkerPool MapEFToBO(
			WorkerPool efWorkerPool);

		List<BOWorkerPool> MapEFToBO(
			List<WorkerPool> records);
	}
}

/*<Codenesium>
    <Hash>3aadba4d05646ce09e6a7b5a8fd2fe57</Hash>
</Codenesium>*/