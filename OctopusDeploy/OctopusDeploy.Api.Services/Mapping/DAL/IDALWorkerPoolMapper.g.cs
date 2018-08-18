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
    <Hash>08cd50126b5e9a255ab566aa1d2b489f</Hash>
</Codenesium>*/