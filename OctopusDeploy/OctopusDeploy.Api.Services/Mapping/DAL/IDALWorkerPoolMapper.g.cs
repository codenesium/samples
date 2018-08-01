using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALWorkerPoolMapper
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
    <Hash>d23fc57a4aba3ae91e8ad5084effa484</Hash>
</Codenesium>*/